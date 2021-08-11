using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TenmoServer.Models;
using TenmoServer.Security;
using TenmoServer.Security.Models;

namespace TenmoServer.DAO
{
    public class UserSqlDAO : IUserDAO
    {
        private readonly string connectionString;
        const decimal startingBalance = 1000;
       
        public UserSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public User GetUser(string username)
        {
            User returnUser = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT user_id, username, password_hash, salt FROM users WHERE username = @username", conn);
                cmd.Parameters.AddWithValue("@username", username);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows && reader.Read())
                {
                    returnUser = GetUserFromReader(reader);
                }
            }

            return returnUser;
        }

        public List<User> GetUsers()
        {
            List<User> returnUsers = new List<User>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT user_id, username, password_hash, salt FROM users", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        User u = GetUserFromReader(reader);
                        returnUsers.Add(u);
                    }

                }
            }

            return returnUsers;
        }

        public User AddUser(string username, string password)
        {
            IPasswordHasher passwordHasher = new PasswordHasher();
            PasswordHash hash = passwordHasher.ComputeHash(password);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO users (username, password_hash, salt) VALUES (@username, @password_hash, @salt)", conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password_hash", hash.Password);
                cmd.Parameters.AddWithValue("@salt", hash.Salt);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("SELECT @@IDENTITY", conn);
                int userId = Convert.ToInt32(cmd.ExecuteScalar());

                cmd = new SqlCommand("INSERT INTO accounts (user_id, balance) VALUES (@userid, @startBalance)", conn);
                cmd.Parameters.AddWithValue("@userid", userId);
                cmd.Parameters.AddWithValue("@startBalance", startingBalance);
                cmd.ExecuteNonQuery();
            }

            return GetUser(username);
        }

        private User GetUserFromReader(SqlDataReader reader)
        {
            return new User()
            {
                UserId = Convert.ToInt32(reader["user_id"]),
                Username = Convert.ToString(reader["username"]),
                PasswordHash = Convert.ToString(reader["password_hash"]),
                Salt = Convert.ToString(reader["salt"]),
            };
        }

        private string sqlGetCurrentUser = "SELECT user_id, balance, account_id " +
        "FROM accounts " +
        "WHERE user_id = @userId; ";
        public Account GetCurrentUser(int currentUserId)
        {
            Account account = new Account();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlGetCurrentUser, conn);
                    cmd.Parameters.AddWithValue("@userId", currentUserId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        account.UserId = Convert.ToInt32(reader["user_id"]);
                        account.Balance = Convert.ToDecimal(reader["balance"]);
                        account.AccountId = Convert.ToInt32(reader["account_id"]);


                    }

                }

            }
            catch (Exception ex)
            {
                account = new Account();
            }

            return account;


        }


        private string sqlGetUserName = "SELECT username " +
            "FROM users " +
            "JOIN accounts ON users.user_id = accounts.user_id " +
            "WHERE account_id = @accountId; ";
        public string GetUserName(int accountId)
        {
            string username = "";

            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlGetUserName, conn);
                cmd.Parameters.AddWithValue("@accountId", accountId);

                username = (string)cmd.ExecuteScalar();
            }
            return username;
        }
    }
}
