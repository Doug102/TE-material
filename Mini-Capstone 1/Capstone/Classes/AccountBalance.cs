using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class AccountBalance
    {
        public FileAccess fileAccess = new FileAccess();
        public decimal Balance { get; set; }
     
        public decimal TotalBalance { get; set; } = 0;
        public void AddMoney(decimal moneyAdded)
        {
            if ((moneyAdded + TotalBalance) <= 5000)
            {
                TotalBalance += moneyAdded;
            }
            else
            {
                TotalBalance = TotalBalance + 0;
            }
        }

        public string GetChange()   // breaks total balance done into correct change denominations
        {
            //fileAccess.SalesReport();
            fileAccess.WritingFile("GET CHANGE: ", TotalBalance, 0.00M); // writes get change info in log
            Console.WriteLine("Log has been updated.");
            Console.WriteLine("");

            int twenties = 0;
            int tens = 0;
            int fives = 0;
            int ones = 0;
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;



            if (TotalBalance / 20 >= 1)
            {
                twenties = (int)(TotalBalance / 20);  // check max amount of twenties back
                TotalBalance -= twenties * 20;
            }
            if (TotalBalance / 10 >= 1)
            {
                tens = (int)(TotalBalance / 10); // check max amount of tens back
                TotalBalance -= tens * 10;
            }
            if (TotalBalance / 5 >= 1)
            {
                fives = (int)(TotalBalance / 5); // check max amount of fives back
                TotalBalance -= fives * 5;
            }
            if (TotalBalance / 1 >= 1)
            {
                ones = (int)(TotalBalance / 1); // check max amount of ones back
                TotalBalance -= ones;
            }
            if (TotalBalance / 0.25M >= 1)
            {
                quarters = (int)(TotalBalance / 0.25M); // check max amount of quarters back
                TotalBalance -= quarters * 0.25M;
            }
            if (TotalBalance / 0.10M >= 1)
            {
                dimes = (int)(TotalBalance / 0.10M);  // check max amount of dimes back
                TotalBalance -= dimes * 0.10M;
            }
            if (TotalBalance / 0.05M >= 1)
            {
                nickels = (int)(TotalBalance / 0.05M); // check max amount of nickels back
                TotalBalance -= nickels * 0.05M;
            }
            string result = $"Change back: {twenties} twenties, {tens} tens, {fives} fives, {ones} ones, {quarters} quarters, {dimes} dimes, {nickels} nickels.";
            return result;
        }


    }
}
