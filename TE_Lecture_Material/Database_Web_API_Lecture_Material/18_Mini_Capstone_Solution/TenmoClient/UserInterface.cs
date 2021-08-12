using System;
using System.Collections.Generic;
using TenmoClient.APIClients;
using TenmoClient.Data;

namespace TenmoClient
{
    public class UserInterface
    {
        private readonly ConsoleService consoleService = new ConsoleService();
        private readonly AuthService authService = new AuthService();
        private readonly AccountService accountService = new AccountService();
        private readonly UserServices userServices = new UserServices();
        private readonly TransferService transferService = new TransferService();

        private bool shouldExit = false;

        public void Start()
        {
            while (!shouldExit)
            {
                while (!authService.IsLoggedIn)
                {
                    ShowLogInMenu();
                }

                // If we got here, then the user is logged in. Go ahead and show the main menu
                ShowMainMenu();
            }
        }

        private void ShowLogInMenu()
        {
            Console.WriteLine("Welcome to TEnmo!");
            Console.WriteLine("1: Login");
            Console.WriteLine("2: Register");
            Console.WriteLine("0: Exit");
            Console.Write("Please choose an option: ");

            if (!int.TryParse(Console.ReadLine(), out int loginRegister))
            {
                Console.WriteLine("Invalid input. Please enter only a number.");
            }
            else if (loginRegister == 1)
            {
                HandleUserLogin();
            }
            else if (loginRegister == 2)
            {
                HandleUserRegister();
            }
            else if (loginRegister == 0)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Please make a valid selection");
            }
        }

        private void ShowMainMenu()
        {
            int menuSelection = -1;
            while (menuSelection != 0)
            {
                Console.WriteLine();
                Console.WriteLine("Welcome to TEnmo! Please make a selection: ");
                Console.WriteLine("1: View your current balance");
                Console.WriteLine("2: View your past transfers");
                Console.WriteLine("3: View your pending requests");
                Console.WriteLine("4: Send TE bucks");
                Console.WriteLine("5: Request TE bucks");
                Console.WriteLine("6: Log in as different user");
                Console.WriteLine("0: Exit");
                Console.WriteLine("---------");
                Console.Write("Please choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out menuSelection))
                {
                    Console.WriteLine("Invalid input. Please enter only a number.");
                }
                else
                {
                    switch (menuSelection)
                    {
                        case 1:
                            GetBalance(UserService.UserId);
                            break;

                        case 2:
                            ShowTransferHistory();
                            Console.WriteLine("Please enter transfer ID to view details (0 to cancel): ");
                            ShowTransferDetails();

                            break;

                        case 3:
                            bool areThereTransfers = ShowPendingTransfers();
                            if (areThereTransfers)
                            {
                                GetPendingTransferFromUser();
                            }
                            break;

                        case 4:
                            if (SendTransferSetUp())
                            {
                                Console.WriteLine();
                                Console.WriteLine("Your transfer was successfully completed.");
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("You transfer was NOT successfully completed.");
                            }
                            break;

                        case 5: //Request TE bucks
                            if (SendRequestSetUp())
                            {
                                Console.WriteLine();
                                Console.WriteLine("Your request was sent!");
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Your request has not been sent, please try again later.");
                            }
                            break;

                        case 6:
                            LogOut();
                            menuSelection = 0;
                            break;
                        case 0:
                            Console.WriteLine("Goodbye!");
                            shouldExit = true;
                            return;
                        default:
                            Console.WriteLine();
                            Console.WriteLine("Please make a valid selection.");
                            break;

                    }
                }
            }
        }

        private int GetRecipientId()
        {
            Console.WriteLine();
            bool done = false;
            int recipientId = 0;
            while (!done)
            {
                bool valid = int.TryParse(Console.ReadLine(), out recipientId);
                if (valid)
                {
                    done = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid ID number.");
                }
            }
            return recipientId;
        }

        private decimal GetTransferAmount()
        {
            Console.WriteLine();
            bool done = false;
            decimal transferAmount = 0;
            while (!done)
            {
                bool valid = decimal.TryParse(Console.ReadLine(), out transferAmount);
                if (valid)
                {
                    done = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid ID number.");
                }
            }
            return transferAmount;
        }
        private void GetBalance(int userId)
        {
            decimal balance = accountService.GetBalance(userId);
            Console.Write($"Your current account balance is: ${balance}");
            Console.WriteLine();
        }

        private bool ShowPendingTransfers()
        {
            bool areThereTransfers = false;
            List<Transfer> pendingTransfers = transferService.ListPendingTransfersByUserId(UserService.UserId);
            if (pendingTransfers.Count == 0)
            {
                Console.WriteLine("No pending transfers at this time.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Transfer ID".PadRight(15) + "From".PadRight(16) + "To".PadRight(13) + "Amount".PadRight(17) + "Transfer Status");
                Console.WriteLine();
                foreach (Transfer transfer in pendingTransfers)
                {
                    Console.WriteLine(Convert.ToString(transfer.TransferId).PadRight(15) + "From: " + Convert.ToString(transfer.SenderUsername).PadRight(10) +
                    "To: " + Convert.ToString(transfer.RecipientUsername).PadRight(10) + "$ " + Convert.ToString(transfer.Amount).PadRight(16) + transfer.TransferStatus);
                }
                areThereTransfers = true;
            }
            Console.WriteLine();
            return areThereTransfers;
        }

        private void GetPendingTransferFromUser()
        {
            Transfer tr = GetPendingTransferById();
            if (tr.TransferId == -1)
            {
                return;
            }
            if (tr.SenderUserId == UserService.UserId)
            {
                ApproveOrRejectRequest(tr);
            }
            else
            {
                Console.WriteLine("Can't send yourself money from someone else's account!");
                return;
            }
        }

        private void ApproveOrRejectRequest(Transfer tr)
        {
            Console.Write("(A)pprove or (R)eject? (0 to exit): ");
            string input = Console.ReadLine();
            switch (input.ToLower())
            {
                case "a":
                    tr.TransferStatus = "Approved";
                    bool approve = transferService.ApproveOrRejectRequest(tr);
                    if (approve)
                    {
                        Console.WriteLine($"Successfully approved request #{tr.TransferId}.");
                    }
                    else
                    {
                        Console.WriteLine($"Failed to approve request #{tr.TransferId}.");
                    }
                    break;
                case "r":
                    tr.TransferStatus = "Rejected";
                    bool reject = transferService.ApproveOrRejectRequest(tr);
                    if (reject)
                    {
                        Console.WriteLine($"Successfully rejected request #{tr.TransferId}.");
                    }
                    else
                    {
                        Console.WriteLine($"Failed to reject request #{tr.TransferId}.");
                    }
                    break;
                default:
                    break;
            }
        }

        private Transfer GetPendingTransferById()
        {
            Transfer tr = new Transfer();
            List<Transfer> pendingTransfers = transferService.ListPendingTransfersByUserId(UserService.UserId);

            Console.WriteLine("Please enter transfer ID to approve/reject (0 to cancel): ");
            bool done = false;
            int transferSelection = 0;
            while (!done)
            {
                bool validEntry = int.TryParse(Console.ReadLine(), out transferSelection);
                if (!validEntry)
                {
                    Console.WriteLine("Please enter a valid ID number.");
                }
                else
                {
                    done = true;
                }
            }
            tr.TransferId = -1;
            foreach (Transfer transfer in pendingTransfers)
            {
                if (transfer.TransferId == transferSelection)
                {
                    tr = transfer;
                }
            }
            if (tr.TransferId == -1 && transferSelection != 0)
            {
                Console.WriteLine("Not a valid ID number, please try again.");
            }
            return tr;
        }

        private void ShowTransferHistory()
        {
            List<Transfer> transferHistory = transferService.ListTransfersByUserId(UserService.UserId);
            Console.WriteLine("Transfer ID" + "From/To".PadLeft(10) + "Amount".PadLeft(20));
            Console.WriteLine();
            foreach (Transfer transfer in transferHistory)
            {
                Console.WriteLine(transfer.TransferId + "From: ".PadLeft(10) + transfer.SenderUsername +
                    "To: ".PadLeft(10) + transfer.RecipientUsername + "$ ".PadLeft(20) + transfer.Amount);
            }

            Console.WriteLine();
        }

        private void ShowTransferDetails()
        {
            List<Transfer> transferHistory = transferService.ListTransfersByUserId(UserService.UserId);
            bool done = false;
            int transferSelection = 0;
            while (!done)
            {
                bool validEntry = int.TryParse(Console.ReadLine(), out transferSelection);
                if (!validEntry)
                {
                    Console.WriteLine("Please enter a valid ID number.");
                }
                else
                {
                    done = true;
                }               
            }
            bool printed = false;
            foreach (Transfer transfer in transferHistory)
            {
                if (transfer.TransferId == transferSelection)
                {
                    Console.WriteLine();
                    Console.WriteLine("Transfer Details");
                    Console.WriteLine();
                    Console.WriteLine("Transfer ID: " + transfer.TransferId);
                    Console.WriteLine("From: " + transfer.SenderUsername);
                    Console.WriteLine("To: " + transfer.RecipientUsername);
                    Console.WriteLine("Transfer Type: " + transfer.TransferType);
                    Console.WriteLine("Transfer Status: " + transfer.TransferStatus);
                    Console.WriteLine("Transfer Amount: $" + transfer.Amount);
                    printed = true;
                }
            }
            if (!printed && transferSelection != 0)
            {
                Console.WriteLine("Not a valid ID number, please try again.");
            }
        }

        private void ShowUserList(int userId)
        {
            List<API_User> users = userServices.GetUserList(userId);

            Console.WriteLine();
            Console.WriteLine("User ID" + "Name".PadLeft(7));
            Console.WriteLine();

            foreach (API_User user in users)
            {
                int id = user.UserId;
                string name = user.Username;

                Console.WriteLine(id + name.PadLeft(10));
            }
            Console.WriteLine();
        }

        private bool SendTransferSetUp()
        {
            ShowUserList(UserService.UserId);

            Console.Write("Enter ID of user you are sending to (0 to cancel): ");
            int id = GetRecipientId();
            if (id != 0)
            {
                Console.Write("Enter the amount you would like to send: ");
                decimal amount = GetTransferAmount();
                Transfer temp = new Transfer();
                temp.Amount = amount;
                temp.RecipientUserId = id;
                temp.SenderUserId = UserService.UserId;
                transferService.CreateNewSendTransfer(temp);
                return true;
            }
            return false;
        }

        private bool SendRequestSetUp()
        {
            ShowUserList(UserService.UserId);

            Console.Write("Enter ID of user you are requesting TE bucks from (0 to cancel): ");
            int id = GetRecipientId();
            if (id != 0)
            {
                Console.Write("Enter the amount you would like to request: ");
                decimal amount = GetTransferAmount();
                Transfer temp = new Transfer();
                temp.Amount = amount;
                temp.RecipientUserId = UserService.UserId;
                temp.SenderUserId = id;
                if (transferService.CreateNewRequest(temp))
                {
                    return true; // **********this was not here before 3/10/2021, caught right before code review :)
                }
            }
            return false;
        }

        private void HandleUserRegister()
        {
            bool isRegistered = false;

            while (!isRegistered) //will keep looping until user is registered
            {
                LoginUser registerUser = consoleService.PromptForLogin();
                isRegistered = authService.Register(registerUser);
            }

            Console.WriteLine("");
            Console.WriteLine("Registration successful. You can now log in.");
        }

        private void HandleUserLogin()
        {
            int timeOut = 0;
            while (!UserService.IsLoggedIn) //will keep looping until user is logged in
            {
                LoginUser loginUser = consoleService.PromptForLogin();
                API_User user = authService.Login(loginUser);
                if (user != null && timeOut < 3)
                {
                    UserService.SetLogin(user);
                }
                return;
            }
        }

        private void LogOut()
        {
            Console.WriteLine();
            UserService.SetLogin(new API_User()); //wipe out previous login info
            authService.Logout();
            Console.WriteLine();
            return;
        }

    }
}
