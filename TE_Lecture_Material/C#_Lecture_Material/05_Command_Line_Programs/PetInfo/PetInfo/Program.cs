using System;

namespace PetInfo
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please enter the number of values. (ex: 2)");
            string stringCount = Console.ReadLine();
            int count = int.Parse(stringCount); 

            string[] userInputs = new string[count];

            Console.WriteLine("Please enter " + count +" values, one per line.");

            for (int i = 0; i < userInputs.Length; i++)
            {
                 userInputs[i] = Console.ReadLine();
            }

            for (int i = userInputs.Length-1; i >= 0; i--)
            {
                Console.WriteLine("You typed in:" + userInputs[i]);
            }

            return;
        }
    }
}
