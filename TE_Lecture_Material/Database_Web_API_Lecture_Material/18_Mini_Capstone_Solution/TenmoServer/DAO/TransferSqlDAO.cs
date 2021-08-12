using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public class TransferSqlDAO : ITransferDAO
    {
        private readonly string connectionString;

        private string sqlCreateNewTransfer = "  INSERT INTO transfers " +
            "(transfer_type_id, transfer_status_id, account_from, account_to, amount) " +
            "VALUES (@transfertypeid, @transferstatusid, @accountfrom, @accountto, @amount)" +
            " SELECT SCOPE_IDENTITY();";

        private string sqlGetAccountFromUserId = "SELECT account_id FROM accounts WHERE user_id = @userid";
        private string sqlGetUserIdFromAccount = "SELECT user_id FROM accounts WHERE account_id = @accId";

        private string sqlRemoveMoneyFromAccount = "UPDATE accounts SET balance = balance - @amount WHERE account_id = @accountfrom;";
        private string sqlAddMoneyToAccount = " UPDATE accounts SET balance = balance + @amount WHERE account_id = @accountto;";

        private string sqlGetTransfersById = 
        "SELECT tr.transfer_id AS 'TransferId', tr.account_from AS 'AccountFrom', " +
        "tr.account_to AS 'AccountTo', tr.amount AS 'Amount', tt.transfer_type_desc AS 'TransferType', " +
        "ts.transfer_status_desc AS 'TransferStatus' FROM transfers tr " +
        "JOIN transfer_statuses ts ON ts.transfer_status_id = tr.transfer_status_id " +
        "JOIN transfer_types tt ON tt.transfer_type_id = tr.transfer_type_id " +
        "WHERE (account_from = @accId AND (ts.transfer_status_id = 2001 OR ts.transfer_status_id = 2002)) OR (account_to = @accId AND (ts.transfer_status_id = 2001 OR ts.transfer_status_id = 2002));";

        private string sqlGetPendingTransfersById =
        "SELECT tr.transfer_id AS 'TransferId', tr.account_from AS 'AccountFrom', " +
        "tr.account_to AS 'AccountTo', tr.amount AS 'Amount', tt.transfer_type_desc AS 'TransferType', " +
        "ts.transfer_status_desc AS 'TransferStatus' FROM transfers tr " +
        "JOIN transfer_statuses ts ON ts.transfer_status_id = tr.transfer_status_id " +
        "JOIN transfer_types tt ON tt.transfer_type_id = tr.transfer_type_id " +
        "WHERE account_from = @accId AND ts.transfer_status_id = 2000 OR account_to = @accId AND ts.transfer_status_id = 2000;";

        private string sqlApproveRequest = "UPDATE transfers SET transfer_status_id = 2001 WHERE transfer_id = @transferId";
        private string sqlRejectRequest = "UPDATE transfers SET transfer_status_id = 2002 WHERE transfer_id = @transferId";

        public TransferSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public int GetAccountFromUserId(int userId)
        {
            int accountId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetAccountFromUserId, conn);
                    cmd.Parameters.AddWithValue("@userid", userId);

                    accountId = Convert.ToInt32(cmd.ExecuteScalar()); 
                }
            }
            catch (SqlException ex)
            {
                accountId = 0;
            }
            return accountId;
        }

        public int GetUserIdFromAccount(int accId)
        {
            int userId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetUserIdFromAccount, conn);
                    cmd.Parameters.AddWithValue("@accId", accId);

                    userId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                userId = 0;
            }

            return userId;
        }

        public int CreateNewSendTransfer(decimal amount, int accId, int recipientAccId)
        {
            int transferId = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlCreateNewTransfer, conn);
                cmd.Parameters.AddWithValue("@transfertypeid", 1001); //always 1001 for this type of transfer
                cmd.Parameters.AddWithValue("@transferstatusid", 2001); //always 2001 for this type of transfer
                cmd.Parameters.AddWithValue("@accountfrom", accId);
                cmd.Parameters.AddWithValue("@accountto", recipientAccId);
                cmd.Parameters.AddWithValue("@amount", amount);

                transferId = Convert.ToInt32(cmd.ExecuteScalar());

                bool moneyTransferred = MoveMoneyBetweenAccounts(amount, accId, recipientAccId);
                if (!moneyTransferred)
                {
                    transferId = 0;
                }

            }
            return transferId;
        }

        public int CreateNewRequest(decimal amount, int accId, int recipientAccId)
        {
            int transferId = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlCreateNewTransfer, conn);
                cmd.Parameters.AddWithValue("@transfertypeid", 1000); //always 1000 for this type of transfer
                cmd.Parameters.AddWithValue("@transferstatusid", 2000); //always 2000 for this type of transfer
                cmd.Parameters.AddWithValue("@accountfrom", accId);
                cmd.Parameters.AddWithValue("@accountto", recipientAccId);
                cmd.Parameters.AddWithValue("@amount", amount);

                transferId = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return transferId;
        }

        public bool MoveMoneyBetweenAccounts(decimal amount, int accId, int recipientAccId)
        {
            bool sent = false;
            bool received = false;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlRemoveMoneyFromAccount, conn);
                cmd.Parameters.AddWithValue("@accountfrom", accId);
                cmd.Parameters.AddWithValue("@amount", amount);

                int count = Convert.ToInt32(cmd.ExecuteNonQuery());
                if (count > 0)
                {
                    sent = true;
                }

                SqlCommand cmd2 = new SqlCommand(sqlAddMoneyToAccount, conn);
                cmd2.Parameters.AddWithValue("@accountto", recipientAccId);
                cmd2.Parameters.AddWithValue("@amount", amount);

                int count2 = Convert.ToInt32(cmd2.ExecuteNonQuery());
                if (count2 > 0)
                {
                    received = true;
                }

            }
            return (sent == true && received == true);
        }

        public List<Transfer> GetPendingTransferById(int accId)
        {
            List<Transfer> userTransfers = new List<Transfer>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            { 
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlGetPendingTransfersById, conn);
                cmd.Parameters.AddWithValue("@accId", accId);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Transfer transfer = new Transfer();
                    transfer.TransferId = Convert.ToInt32(reader["TransferId"]);
                    transfer.SenderUserId = GetUserIdFromAccount(Convert.ToInt32(reader["AccountFrom"]));
                    transfer.RecipientUserId = GetUserIdFromAccount(Convert.ToInt32(reader["AccountTo"]));
                    transfer.Amount = Convert.ToDecimal(reader["Amount"]);
                    transfer.TransferType = Convert.ToString(reader["TransferType"]);
                    transfer.TransferStatus = Convert.ToString(reader["TransferStatus"]);

                    userTransfers.Add(transfer);
                } 
            }
            return userTransfers;
        }

        public List<Transfer> GetTransferById(int accId)
        {
            List<Transfer> userTransfers = new List<Transfer>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlGetTransfersById, conn);
                cmd.Parameters.AddWithValue("@accId", accId);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Transfer transfer = new Transfer();
                    transfer.TransferId = Convert.ToInt32(reader["TransferId"]);
                    transfer.SenderUserId = GetUserIdFromAccount(Convert.ToInt32(reader["AccountFrom"]));
                    transfer.RecipientUserId = GetUserIdFromAccount(Convert.ToInt32(reader["AccountTo"]));
                    transfer.Amount = Convert.ToDecimal(reader["Amount"]);
                    transfer.TransferType = Convert.ToString(reader["TransferType"]);
                    transfer.TransferStatus = Convert.ToString(reader["TransferStatus"]);

                    userTransfers.Add(transfer);
                }  
            }
            return userTransfers;
        }

        public bool ApproveRequest(Transfer transfer)
        {
            bool statusUpdated = false;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlApproveRequest, conn);
                cmd.Parameters.AddWithValue("@transferId", transfer.TransferId);

                int count = Convert.ToInt32(cmd.ExecuteNonQuery());
                if (count > 0)
                {
                    statusUpdated = true;
                }
            }

            bool moneyMoved = false;
            int accId = GetAccountFromUserId(transfer.SenderUserId);
            int recipientAccId = GetAccountFromUserId(transfer.RecipientUserId);
            if (MoveMoneyBetweenAccounts(transfer.Amount, accId, recipientAccId))
            {
                moneyMoved = true;
            }

            return (statusUpdated & moneyMoved);
        }

        public bool RejectRequest(Transfer transfer)
        {
            bool rejected = false;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlRejectRequest, conn);
                cmd.Parameters.AddWithValue("@transferId", transfer.TransferId);

                int count = Convert.ToInt32(cmd.ExecuteNonQuery());
                if (count > 0)
                {
                    rejected = true;
                }
            }

            return rejected;
        }
    }
}
