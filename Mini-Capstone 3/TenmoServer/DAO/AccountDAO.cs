using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public class AccountDAO : IAccountDAO
    {
        private readonly string connectionString;

        public AccountDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Account GetBalance(int userId)
        {
            Account returnAccount = new Account();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM accounts WHERE user_id = @userId", conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    returnAccount.AccountId = Convert.ToInt32(reader["account_id"]);
                    returnAccount.UserId = Convert.ToInt32(reader["user_id"]);
                    returnAccount.Balance = Convert.ToDecimal(reader["balance"]);
                }
            }

            return returnAccount;
        }




        string sqlString = "UPDATE accounts " +
            "SET balance = balance - @amount " +
            "WHERE account_id = @id; " +
            "UPDATE accounts " +
            "SET balance = balance + @amount " +
            "WHERE account_id = @idtwo";


        public bool UpdateFromAccountBalance(Transfer transfer)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                cmd.Parameters.AddWithValue("@amount", transfer.Amount);
                cmd.Parameters.AddWithValue("@id", transfer.AccountFrom);
                cmd.Parameters.AddWithValue("@idtwo", transfer.AccountTo);
                int count = cmd.ExecuteNonQuery();

                if (count > 1)
                {
                    result = true;
                }


            }



            return result;
        }

        string sqlToString = "UPDATE accounts " +
                             "SET balance = balance - @amount " +
                             "WHERE account_id = @id; " +
                             "UPDATE accounts " +
                             "SET balance = balance + @amount " +
                             "WHERE account_id = @idtwo";


        public bool UpdateToAccountBalance(Transfer transfer)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlToString, conn);
                cmd.Parameters.AddWithValue("@amount", transfer.Amount);
                cmd.Parameters.AddWithValue("@id", transfer.AccountFrom);
                cmd.Parameters.AddWithValue("@idtwo", transfer.AccountTo);
                int count = cmd.ExecuteNonQuery();

                if (count > 1)
                {
                    result = true;
                }


            }



            return result;
        }
        private string sqlGetAccountId = "Select account_id FROM accounts WHERE accounts.user_id = @id;";
        public int GetAccountIdFromUserId(int id)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlGetAccountId, conn);
                cmd.Parameters.AddWithValue("@id", id);
                result = (int)(cmd.ExecuteScalar());
            }
            return result;
        }

        private string sqlGetUserName = "SELECT username " +
            "FROM users " +
            "JOIN accounts ON users.user_id = accounts.user_id " +
            "WHERE account_id = @accountId; ";
        public Account GetUserNameByAccountId(int id)
        {
            Account account = new Account();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlGetUserName, conn);
                cmd.Parameters.AddWithValue("@accountId", id);
                account.UserName = (string)(cmd.ExecuteScalar());
            }
            return account;
        }







    }
}
