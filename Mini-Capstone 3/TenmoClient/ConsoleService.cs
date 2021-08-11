using System;
using System.Collections.Generic;
using TenmoClient.APIClients;
using TenmoClient.Data;

namespace TenmoClient
{
    public class ConsoleService
    {
        private readonly AccountServices accountServices = new AccountServices();
        private readonly TransferServices transferServices = new TransferServices();
        private readonly UsersServices usersServices = new UsersServices();
        private API_User api_User = new API_User();

        public void UserIdAndName(API_User user)
        {
            api_User.UserId = user.UserId;
            api_User.Username = user.Username;
        }
        public void CaseOne()
        {

            Console.WriteLine("Your account balance is: " + accountServices.GetBalance().ToString("C"));
        }
        public void CaseTwo()
        {
            List<Transfer> transfers = transferServices.GetTransfersForId(accountServices.GetAccountIdFromUserId(api_User.UserId));
            DisplayListOfTransfers(transfers);
            Console.Write("Enter a transfer ID to get details: ");
            int transferID = 0;
            try
            {
                transferID = int.Parse(Console.ReadLine());

            }
            catch (Exception e)
            {
                Console.WriteLine("invalid transfer ID please enter an interger.");
                return;
            }
            try
            {
                Transfer transfer = GetTransferBasedOnTransferId(transferID, transfers);
                DisplayTransferDetails(transfer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void CaseThree()
        {
            List<Transfer> pendingTransfers = transferServices.GetTransfersForId(accountServices.GetAccountIdFromUserId(api_User.UserId));
            DisplayListOfPendingTransfers(pendingTransfers);
            Console.Write("Enter a transfer ID to approve/reject: ");
            int pendingTransferID = 0;
            try
            {
                pendingTransferID = int.Parse(Console.ReadLine());

            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid transfer ID please enter an integer.");
                return;
            }
            try
            {
                Transfer transfer = GetTransferBasedOnTransferId(pendingTransferID, pendingTransfers);
                DisplayTransferDetails(transfer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            Transfer transfer2 = new Transfer();
            try
            {
                transfer2 = GetTransferBasedOnTransferId(pendingTransferID, pendingTransfers);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;

            }


            if (transfer2.AccountTo != accountServices.GetAccountIdFromUserId(api_User.UserId))
            {
                ApproveOrRejectMenu(pendingTransferID, pendingTransfers);


            }
            else
            {
                Console.WriteLine("You are unable to accept/reject requests you've made. ");
            }
        }
        public void CaseFour()
        {
            List<int> availableUsers = DisplayUsers();
            Transfer newTransfer = new Transfer();
            try
            {
                newTransfer = PromptUserForTransferInfo(availableUsers);
                if (newTransfer != null)
                {
                    transferServices.TransferTEBucks(newTransfer);
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine("Transfer Approved.");
                    Console.WriteLine("-------------------------------------------");
                    //todo

                }
                else
                {
                    Console.WriteLine("Invalid transfer, please try again.");
                }
            }
            catch (Exception e)
            {
                if (e.Message == "Invalid user id, please try again.")
                {
                    Console.WriteLine(e.Message);
                }
                else
                {
                    Console.WriteLine("insufficient balance for transfer please try again.");
                }
            }
        }
        public void CaseFive()
        {
            List<int> availableUsersForRequest = DisplayUsers();
            Transfer newTransfer = new Transfer();
            try
            {
                newTransfer = PromptUserForRequestInfo(availableUsersForRequest);
                if (newTransfer != null)
                {
                    transferServices.TransferTEBucks(newTransfer);
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine("Transfer Pending.");
                    Console.WriteLine("-------------------------------------------");
                    //todo

                }
                else
                {
                    Console.WriteLine("Invalid transfer, please try again.");
                }
            }
            catch (Exception e)
            {
                if (e.Message == "Invalid user id, please try again.")
                {
                    Console.WriteLine(e.Message);
                }
                else
                {
                    Console.WriteLine("Insufficient balance for transfer please try again.");
                }
            }
        }


        public int PromptForTransferID(string action)
        {
            Console.WriteLine("");
            Console.Write($"Please enter transfer ID to {action} (0 to cancel): ");

            if (!int.TryParse(Console.ReadLine(), out int auctionId))
            {
                Console.WriteLine("Invalid input. Only input a number.");
                return 0;
            }

            return auctionId;
        }

        public LoginUser PromptForLogin()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            string password = GetPasswordFromConsole("Password: ");

            return new LoginUser
            {
                Username = username,
                Password = password
            };
        }

        private string GetPasswordFromConsole(string displayMessage)
        {
            string pass = "";
            Console.Write(displayMessage);
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                // Backspace Should Not Work
                if (!char.IsControl(key.KeyChar))
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Remove(pass.Length - 1);
                        Console.Write("\b \b");
                    }
                }
            }

            // Stops Receving Keys Once Enter is Pressed
            while (key.Key != ConsoleKey.Enter);
            Console.WriteLine("");

            return pass;
        }
        public Transfer GetTransfer(int id, decimal amount, Account fromAccount)
        {
            Transfer transfer = new Transfer();
            if (amount <= fromAccount.Balance)
            {

                transfer.AccountTo = id;
                transfer.Amount = amount;
                transfer.TransferTypeId = 1001;
                transfer.TransferStatusId = 2001;
            }
            return transfer;
        }

        public Transfer GetRequest(int id, decimal amount, Account fromAccount)
        {
            Transfer transfer = new Transfer();
            if (amount <= fromAccount.Balance)
            {

                transfer.AccountTo = id;
                transfer.Amount = amount;
                transfer.TransferTypeId = 1000;
                transfer.TransferStatusId = 2000;
            }
            return transfer;
        }
        private List<int> DisplayUsers()
        {
            List<API_User> users = usersServices.GetUsers();
            List<int> result = new List<int>();


            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Users");
            Console.WriteLine("ID".PadRight(10) + "Name");
            Console.WriteLine("-------------------------------------------");

            foreach (API_User user in users)
            {
                if (user.UserId != api_User.UserId)
                {
                    result.Add(user.UserId);
                    Console.WriteLine(user.UserId.ToString().PadRight(10) + user.Username.PadRight(20));
                }
            }
            Console.WriteLine("-------------------------------------------");
            return result;
        }
        private Transfer PromptUserForTransferInfo(List<int> availableUsers)
        {
            int transferToAccountId = 0;
            decimal amountToTransfer = 0.00M;
            Transfer transfer = new Transfer();
            try
            {
                Console.Write("Please enter a User ID to transfer to: ");
                transferToAccountId = int.Parse(Console.ReadLine());

            }
            catch (Exception)
            {
                Console.WriteLine("Please enter an integer value");
            }
            try
            {
                Console.Write("Please enter an amount to transfer: ");
                amountToTransfer = decimal.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("please enter a decimal value (xx.xx)");
            }

            if (availableUsers.Contains(transferToAccountId))
            {
                Account fromAccount = usersServices.GetCurrentUser(api_User.UserId);
                int accountFromId = accountServices.GetAccountIdFromUserId(api_User.UserId);
                fromAccount.AccountId = accountFromId;
                int accountId = accountServices.GetAccountIdFromUserId(transferToAccountId);
                transfer = GetTransfer(accountId, amountToTransfer, fromAccount);
                transfer.AccountFrom = fromAccount.AccountId;
            }
            else
            {
                throw new Exception("Invalid user id, please try again.");
            }
            return transfer;
        }

        private Transfer PromptUserForRequestInfo(List<int> availableUsers)
        {
            int transferToAccountId = accountServices.GetAccountIdFromUserId(api_User.UserId);
            int transferFromAccountId = 0;
            decimal amountToTransfer = 0.00M;
            Transfer transfer = new Transfer();
            try
            {
                Console.Write("Please enter a User ID to request from: ");
                transferFromAccountId = int.Parse(Console.ReadLine());

            }
            catch (Exception)
            {
                Console.WriteLine("Please enter an integer value");
            }
            try
            {
                Console.Write("Please enter an amount to transfer: ");
                amountToTransfer = decimal.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("please enter a decimal value (xx.xx)");
            }

            if (availableUsers.Contains(transferFromAccountId))
            {
                Account fromAccount = usersServices.GetCurrentUser(transferFromAccountId);
                int accountFromId = accountServices.GetAccountIdFromUserId(transferFromAccountId);
                fromAccount.AccountId = accountFromId;
                int accountToId = accountServices.GetAccountIdFromUserId(api_User.UserId);
                transfer = GetRequest(accountToId, amountToTransfer, fromAccount);
                transfer.AccountFrom = fromAccount.AccountId;
            }
            else
            {
                throw new Exception("Invalid user id, please try again.");
            }
            return transfer;
        }

        public void DisplayListOfTransfers(List<Transfer> transfers)
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Transfers");
            Console.WriteLine("ID".PadRight(10) + "From/To".PadRight(26) + "Amount".PadRight(3));
            Console.WriteLine("-------------------------------------------");
            foreach (Transfer transfer in transfers)
            {
                //if(transfer.TransferTypeId == 1001)
                string username = accountServices.GetUserNameByAccountId(transfer.AccountTo);
                if (username == api_User.Username)
                {
                    switch (transfer.TransferStatusId)
                    {
                        case 2001:
                            Console.WriteLine(transfer.TransferId.ToString().PadRight(10) + "From:".PadRight(6) + accountServices.GetUserNameByAccountId(transfer.AccountFrom).PadRight(20) + transfer.Amount.ToString("C").PadRight(10));
                            break;
                        case 2000:
                            Console.WriteLine(transfer.TransferId.ToString().PadRight(10) + "From:".PadRight(6) + accountServices.GetUserNameByAccountId(transfer.AccountFrom).PadRight(20) + transfer.Amount.ToString("C").PadRight(10) + "(Pending)");
                            break;
                        case 2002:
                            Console.WriteLine(transfer.TransferId.ToString().PadRight(10) + "From:".PadRight(6) + accountServices.GetUserNameByAccountId(transfer.AccountFrom).PadRight(20) + transfer.Amount.ToString("C").PadRight(10) + "(Rejected)");
                            break;
                    }
                }
                else
                {
                    switch (transfer.TransferStatusId)
                    {
                        case 2001:
                            Console.WriteLine(transfer.TransferId.ToString().PadRight(10) + "To:".PadRight(6) + accountServices.GetUserNameByAccountId(transfer.AccountTo).PadRight(20) + transfer.Amount.ToString("C").PadRight(10));
                            break;
                        case 2000:
                            Console.WriteLine(transfer.TransferId.ToString().PadRight(10) + "To:".PadRight(6) + accountServices.GetUserNameByAccountId(transfer.AccountTo).PadRight(20) + transfer.Amount.ToString("C").PadRight(10) + "(Pending)");
                            break;
                        case 2002:
                            Console.WriteLine(transfer.TransferId.ToString().PadRight(10) + "To:".PadRight(6) + accountServices.GetUserNameByAccountId(transfer.AccountTo).PadRight(20) + transfer.Amount.ToString("C").PadRight(10) + "(Rejected)");
                            break;
                    }

                }
            }
            Console.WriteLine("-------------------------------------------");
        }

        public Transfer GetTransferBasedOnTransferId(int transferId, List<Transfer> transfers)
        {
            Transfer transferSearched = new Transfer();
            foreach (Transfer transfer in transfers)
            {
                if (transfer.TransferId == transferId)
                {
                    transferSearched = transfer;
                }
            }
            if (transferSearched.TransferId != transferId)
            {
                throw new Exception("Transfer not found. Please try again. ");
            }
            return transferSearched;
        }

        public void DisplayTransferDetails(Transfer transfer)
        {
            string fromUsername = accountServices.GetUserNameByAccountId(transfer.AccountFrom);
            string toUsername = accountServices.GetUserNameByAccountId(transfer.AccountTo);

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Transfer Details");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Id: " + transfer.TransferId);
            Console.WriteLine("From: " + fromUsername);
            Console.WriteLine("To: " + toUsername);


            switch (transfer.TransferTypeId)
            {
                case 1000:
                    Console.WriteLine("Type: Request");
                    break;
                case 1001:
                    Console.WriteLine("Type: Send");
                    break;

            }
            switch (transfer.TransferStatusId)
            {
                case 2000:
                    Console.WriteLine("Status: Pending");
                    break;
                case 2001:
                    Console.WriteLine("Status: Approved");
                    break;
                case 2002:
                    Console.WriteLine("Status: Rejected");
                    break;

            }
            Console.WriteLine("Amount: " + transfer.Amount.ToString("C"));
            Console.WriteLine("-------------------------------------------");

        }

        public void DisplayListOfPendingTransfers(List<Transfer> transfers)
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Transfers");
            Console.WriteLine("ID".PadRight(10) + "From/To".PadRight(26) + "Amount".PadRight(3));
            Console.WriteLine("-------------------------------------------");
            foreach (Transfer transfer in transfers)
            {
                //if(transfer.TransferTypeId == 1001)
                string username = accountServices.GetUserNameByAccountId(transfer.AccountTo);
                if (username == api_User.Username)
                {
                    switch (transfer.TransferStatusId)
                    {

                        case 2000:
                            Console.WriteLine(transfer.TransferId.ToString().PadRight(10) + "From:".PadRight(6) + accountServices.GetUserNameByAccountId(transfer.AccountFrom).PadRight(20) + transfer.Amount.ToString("C").PadRight(10));
                            break;
                    }
                }
                else
                {
                    switch (transfer.TransferStatusId)
                    {
                        case 2000:
                            Console.WriteLine(transfer.TransferId.ToString().PadRight(10) + "To:".PadRight(6) + accountServices.GetUserNameByAccountId(transfer.AccountTo).PadRight(20) + transfer.Amount.ToString("C").PadRight(10));
                            break;
                    }

                }
            }
            Console.WriteLine("-------------------------------------------");
        }

        public void ApproveOrRejectMenu(int transferId, List<Transfer> pendingTransfers)
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine("1: Approve");
                Console.WriteLine("2: Reject");
                Console.WriteLine("0: Don't approve or reject");
                Console.WriteLine("-------------------------------------------");
                Console.Write("Please choose an option: ");
                try
                {
                    int approveOrReject = int.Parse(Console.ReadLine());
                    switch (approveOrReject)
                    {
                        case 1:
                            Transfer transfer = GetTransferBasedOnTransferId(transferId, pendingTransfers);
                            transferServices.UpdateTransferApproved(transferId, transfer);
                            done = true;
                            break;

                        case 2:
                            Transfer transferReject = GetTransferBasedOnTransferId(transferId, pendingTransfers);
                            transferServices.UpdateTransferRejected(transferId, transferReject);
                            done = true;
                            break;

                        case 0:
                            return;
                        default:
                            Console.WriteLine("Invalid entry please try again");
                            break;
                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input, please enter an integer.");
                }
            }
        }

    }
}
