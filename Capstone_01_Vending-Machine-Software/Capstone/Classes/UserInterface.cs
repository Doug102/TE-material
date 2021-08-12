using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class UserInterface
    {

        // This class provides all user communications, but not much else.
        // All the "work" of the application should be done elsewhere

        // ALL instances of Console.ReadLine and Console.WriteLine should 
        // be in this class.
        // NO instances of Console.ReadLine or Console.WriteLIne should be
        // in any other class.

        public FileAccess fileAccess = new FileAccess();
        private Catering catering = new Catering();
        private AccountBalance accountBalance = new AccountBalance();
        private List<CateringItem> purchaseList = new List<CateringItem>();

        public void RunInterface()    // starts interface and calls file access to read csv file
        {
            try
            {
                catering.SetItems();
            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading file");
            }
            bool done = false;


            while (!done)   // first menu while loop/switch case
            {
                DisplayMenu();
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        DisplayCateringItems();
                        break;
                    case "2":
                        Order();
                        break;
                    case "3":
                        done = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please enter a valid choice.");
                        break;
                }
            }
        }

        private void DisplayMenu()     // first menu
        {
            Console.WriteLine();
            Console.WriteLine("Please make a selection:");
            Console.WriteLine("(1) - Display Catering Items");
            Console.WriteLine("(2) - Order");
            Console.WriteLine("(3) - Quit the program");
            Console.WriteLine("");
        }

        private void DisplayCateringItems()        // creates item display from catering item list
        {

            foreach (CateringItem item in catering.GetItems())
            {
                Console.WriteLine(item.ToString());
            }
            //DisplayMenu();


        }
        private void MoneyMenu()
        {

            bool done = false;
            while (!done)
            {
                try
                {

                    Console.WriteLine("How much would you like to add to your account?");
                    Console.WriteLine("Enter (Q) to Quit");
                    string userInput = Console.ReadLine();

                    if (userInput == "Q" || userInput == "q")
                    {
                        done = true;
                        break;
                    }
                    decimal moneyAddToCart = (decimal)(int.Parse(userInput));

                    accountBalance.AddMoney(moneyAddToCart);


                    //logging the added money
                    fileAccess.WritingFile("ADD MONEY: ", moneyAddToCart, accountBalance.TotalBalance);
                    Console.WriteLine("Log has been updated.");
                    Console.WriteLine("");



                    Console.WriteLine("Total balance is $" + accountBalance.TotalBalance);
                    break;
                  
                }
                catch (FormatException e)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Invalid. Please enter a whole number");
                    Console.WriteLine("");
                }

            }
        }
        private void Order()       //order menu/switch case
        {

            bool done = false;
            while (!done)
            {
                Console.WriteLine("Please make a selection");
                Console.WriteLine("(1) - Add Money");
                Console.WriteLine("(2) - Select Products");
                Console.WriteLine("(3) - Complete Transaction");
                Console.WriteLine("");
                Console.WriteLine("Current Account Balance: $" + accountBalance.TotalBalance);
                Console.WriteLine("Please make a selection");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        MoneyMenu();     // calls add money menu
                        break;
                    case "2":
                        SelectProducts(); // calls select products menu
                        break;
                    case "3":
                        decimal total = 0;
                        foreach (CateringItem item in purchaseList)
                        {
                            total += item.TotalCost;
                            Console.WriteLine(item.PurchaseListString());       // displays list of items purchased to user

                        }
                        Console.WriteLine("Order total: $" + total);
                        Console.WriteLine(accountBalance.GetChange());     // calls get change to return account balance in proper denominations


                        fileAccess.TotalSalesReport("**TOTAL SALES**", total); //As the order total is processed,
                                                                               //total money spent will be logged in Total Sales Report.

                        //logging the Change back.
                        //fileAccess.WritingFile("Get Change", total, accountBalance.TotalBalance); // writes get change info in log
                        //Console.WriteLine("Log has been updated.");
                        //Console.WriteLine("");

                        done = true;
                       // DisplayMenu();      // once transaction is completed returns to display menu
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please enter a valid choice.");
                        break;
                }
            }
        }

        private void SelectProducts()       // select products menu
        {

            Console.WriteLine("Please enter an item code:");
            string input = Console.ReadLine().ToUpper();
            if (catering.CheckItem(input))         // call checkitem to see if user input matches an item code
            {
                if (catering.CheckSoldOut(input))   // call checksoldout to see if item is sold out
                {
                    bool done = false;
                    while (!done)
                    {
                        Console.WriteLine("Please enter a quantity to purchase:");
                        try
                        {
                            int quantity = int.Parse(Console.ReadLine());         // checks user input to see if an interger was entered, catch format exception if not
                            if (catering.ChangeQuantity(input, quantity))         // calls changequantity to see if enough product exists, subtracts amount to purchase if enough stock exists
                            {
                                decimal totalCost = catering.Purchase(input, quantity, accountBalance.TotalBalance);  // calss purchase to get total cost of requested purchase
                                if (totalCost < accountBalance.TotalBalance)       // checks to ensure customer has enough money to make purchase, if they do continues with purchase
                                {
                                    CateringItem temp = (catering.PurchaseList(input, quantity)); // creates temp catering item with new properties quantity and total cost
                                    purchaseList.Add(temp);


                                    accountBalance.TotalBalance -= totalCost;     // updates account balance after purchase is made
                                    Console.WriteLine("Item purchased");

                                    //logging the added money
                                    //logs each item, number of quantity, and total cost of one item.
                                    fileAccess.SalesReport(temp.Name, temp.Quantity, totalCost);

                                    fileAccess.WritingFileItem(temp.Quantity, temp.Name, temp.Code, totalCost, accountBalance.TotalBalance);  //  writes item purchase info in log
                                    Console.WriteLine("Log has been updated.");
                                    Console.WriteLine("");

                                    done = true;
                                }
                                else
                                {
                                    Console.WriteLine("Insufficient funds, please enter a new quantity.");
                                }

                            }
                            else
                            {
                                Console.WriteLine("Insufficient stock, please enter a new quantity");
                            }
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Invalid quantity, please enter a whole number");
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Item is out of stock");
                }

            }
            else
            {
                Console.WriteLine("Item code does not exist");
            }

        }
    }


}

