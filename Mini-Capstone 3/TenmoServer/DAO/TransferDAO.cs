using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public class TransferDAO : ITransferDAO
    {
        private readonly string connectionString;

        public TransferDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        private string sqlGetUsers = "SELECT user_id, username " +
           "FROM users " +
           "WHERE user_id != @userId; ";
        public List<User> GetUsers(int currentUserId)
        {
            List<User> users = new List<User>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlGetUsers, conn);
                    cmd.Parameters.AddWithValue("@userId", currentUserId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        User user = new User();
                        user.UserId = Convert.ToInt32(reader["user_id"]);
                        user.Username = Convert.ToString(reader["username"]);
                        users.Add(user);

                    }

                }

            }
            catch (Exception ex)
            {
                users = new List<User>();
            }

            return users;


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

        private string sqlPostTransfer = "INSERT INTO transfers (transfer_type_id, transfer_status_id, account_from, account_to, amount) " +
            "Values (@transferTypeId, @transferStatusId, @accountFrom, @accountTo, @amount); ";
        public bool PostTransfer(Transfer transfer)
        {
            AccountDAO accountDAO = new AccountDAO(connectionString);
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlPostTransfer, conn);
                    cmd.Parameters.AddWithValue("@transferTypeId", transfer.TransferTypeId);
                    cmd.Parameters.AddWithValue("@transferStatusId", transfer.TransferStatusId);
                    cmd.Parameters.AddWithValue("@accountFrom", transfer.AccountFrom);
                    cmd.Parameters.AddWithValue("@accountTo", transfer.AccountTo);
                    cmd.Parameters.AddWithValue("@amount", transfer.Amount);

                    int count = cmd.ExecuteNonQuery();

                    if (count > 0)
                    {
                        result = true;
                    }

                }
                if (transfer.TransferStatusId == 2001)
                {
                    accountDAO.UpdateFromAccountBalance(transfer);
                }
            }
            catch (Exception e)
            {
                result = false;
            }

            return result;
        }



        string sqlGetTransfersForId = "SELECT users.username, transfers.transfer_id, transfers.transfer_type_id, transfers.transfer_status_id, transfers.account_from, transfers.account_to, transfers.amount " +
                                    "FROM transfers " +
                                    "JOIN accounts ON transfers.account_from = accounts.account_id " +
                                    "JOIN users ON accounts.user_id = users.user_id " +
                                    "WHERE transfers.account_from = @id OR transfers.account_to = @id ";
        public List<Transfer> GetTransfersForId(int id)
        {
            List<Transfer> transfers = new List<Transfer>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlGetTransfersForId, conn);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Transfer transfer = new Transfer();
                    transfer.AccountFrom = Convert.ToInt32(reader["account_from"]);
                    transfer.AccountTo = Convert.ToInt32(reader["account_to"]);
                    transfer.Amount = Convert.ToDecimal(reader["amount"]);
                    transfer.TransferId = Convert.ToInt32(reader["transfer_id"]);
                    transfer.TransferStatusId = Convert.ToInt32(reader["transfer_status_id"]);
                    transfer.TransferTypeId = Convert.ToInt32(reader["transfer_type_id"]);
                    transfer.UserName = Convert.ToString(reader["username"]);
                    transfers.Add(transfer);
                }

            }
            return transfers;
        }



        string sqlGetTransfersDetailsWithTransferId = "SELECT users.username, transfers.transfer_id, transfers.transfer_type_id, transfers.transfer_status_id, transfers.account_from, transfers.account_to, transfers.amount " +
                            "FROM transfers " +
                            "JOIN accounts ON transfers.account_from = accounts.account_id " +
                            "JOIN users ON accounts.user_id = users.user_id " +
                            "WHERE transfers.transferId = @id ";

        public Transfer GetTransferDetails(int transferId)
        {

            Transfer transfer = new Transfer();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlGetTransfersForId, conn);
                cmd.Parameters.AddWithValue("@id", transferId);

                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    transfer.AccountFrom = Convert.ToInt32(reader["account_from"]);
                    transfer.AccountTo = Convert.ToInt32(reader["account_to"]);
                    transfer.Amount = Convert.ToDecimal(reader["amount"]);
                    transfer.TransferId = Convert.ToInt32(reader["transfer_id"]);
                    transfer.TransferStatusId = Convert.ToInt32(reader["transfer_status_id"]);
                    transfer.TransferTypeId = Convert.ToInt32(reader["transfer_type_id"]);
                    transfer.UserName = Convert.ToString(reader["username"]);

                }

            }
            return transfer;
        }

        private string sqlUpdateTransferApproved = "UPDATE transfers " +
                                                    "SET transfer_status_id = 2001 " +
                                                    "WHERE transfer_id = @id;";
        public bool UpdateTransferApproved(int id, Transfer transfer)
        {
            AccountDAO accountDAO = new AccountDAO(connectionString);
            bool result = false;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlUpdateTransferApproved, conn);
                cmd.Parameters.AddWithValue("@id", id);

                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    result = true;
                    accountDAO.UpdateToAccountBalance(transfer);
                }

            }
            return result;
        }

        private string sqlUpdateTransferRejected = "UPDATE transfers " +
                                                   "SET transfer_status_id = 2002 " +
                                                   "WHERE transfer_id = @id;";
        public bool UpdateTransferRejected(int id)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlUpdateTransferRejected, conn);
                cmd.Parameters.AddWithValue("@id", id);

                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    result = true;
                }

            }
            return result;
        }




    }
}
