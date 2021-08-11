using System;

namespace PetSplit
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter several values, seperated by a space.");
            string userInput = Console.ReadLine();

            string[] words = userInput.Split(' ');

            for(int i = 0; i < words.Length; i++)
            {
                Console.WriteLine((i + 1) + " - " + words[i]);
            }

            return;
        }
    }
}
