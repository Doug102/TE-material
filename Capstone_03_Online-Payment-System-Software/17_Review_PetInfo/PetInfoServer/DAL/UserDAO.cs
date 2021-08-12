
using Microsoft.AspNetCore.Identity;
using PetInfoServer.DAL.Interfaces;
using PetInfoServer.Models;
using PetInfoServer.Security;
using PetInfoServer.Security.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PetInfoServer.DAL
{
    public class UserDAO : IUserDAO
    {

        IPasswordHasher passwordHasher = new PasswordHasher();

        private readonly string connectionString;

        const string sqlGetUser = "SELECT Id, Username, Password, Salt FROM Users WHERE username = @username";

        const string sqlGetUsers = "SELECT Id, Username, Password,Ssalt FROM Users";

        const string sqlAddUser = "INSERT INTO Users (Username, Password, Salt) " +
            "VALUES (@Username, @Password, @Salt)";


        public UserDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public User GetUser(string username)
        {
            User returnUser = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetUser, conn);
                    cmd.Parameters.AddWithValue("@Username", username);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        returnUser = GetUserFromReader(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return returnUser;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Username FROM users";

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new User
                    {
                        Id = (int)reader["Id"],
                        Username = (string)reader["Username"]
                    });
                }
            }

            return users;
        }

        public User AddUser(string username, string password)
        {

            PasswordHash hash = passwordHasher.ComputeHash(password);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlAddUser, conn);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", hash.Password);
                    cmd.Parameters.AddWithValue("@Salt", hash.Salt);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return GetUser(username);
        }


        public bool IsUsernameAndPasswordValid(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Password, Salt FROM users WHERE username = @username";
                command.Parameters.AddWithValue("@Username", username);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string storedPassword = (string)reader["Password"];
                    string storedSalt = (string)reader["Salt"];
                    bool result = passwordHasher.VerifyHashMatch(storedPassword, password, storedSalt);

                    return result;
                }

                return false;
            }
        }

        private User GetUserFromReader(SqlDataReader reader)
        {
            User user = new User()
            {
                Id = Convert.ToInt32(reader["Id"]),
                Username = Convert.ToString(reader["Username"]),
                PasswordHash = Convert.ToString(reader["Password"]),
                Salt = Convert.ToString(reader["Salt"])
            };

            return user;
        }
    }
}


