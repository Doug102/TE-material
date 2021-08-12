using System;

namespace DiscountCalculator
{
    class Program
    {
        /// <summary>
        /// The main method is the start and end of our program.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Discount Calculator");

            // Prompt the user for a discount amount
            // The answer needs to be saved as a double
            Console.Write("Enter the discount amount (w/out percentage): ");
            string userInput = Console.ReadLine();
            double discount = double.Parse(userInput);




            // Prompt the user for a series of prices
            Console.Write("Please provide a series of prices (space separated): ");
            userInput = Console.ReadLine();
            string[] prices = userInput.Split(' ');
            for (int i = 0; i < prices.Length; i++)
            {
                double price = double.Parse(prices[i]);
                double discountedPrice = price - (price * discount);
                Console.WriteLine(price.ToString("c") + " -- " + discountedPrice.ToString("c"));

                
            }






        }
    }
}
