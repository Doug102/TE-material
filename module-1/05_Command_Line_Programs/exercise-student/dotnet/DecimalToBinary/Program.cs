using System;

namespace DecimalToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter in a series of decimal values (separated by spaces): ");
            string decString = Console.ReadLine();
            string[] decStringArray = decString.Split(' ');
            int[] intArray = new int[decStringArray.Length];

            for (int i = 0; i < decStringArray.Length; i++)
            {
                intArray[i] = int.Parse(decStringArray[i]);
                Console.WriteLine(intArray[i] + " in binary is " + Convert.ToString(intArray[i], 2));
            }



        }
    }
}
