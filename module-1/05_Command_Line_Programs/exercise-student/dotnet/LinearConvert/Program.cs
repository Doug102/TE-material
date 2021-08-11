using System;

namespace LinearConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter the length:");
            string lengthString = Console.ReadLine();
            Console.Write("Is the measurement in (m)eter, or (f)eet?");
            string unitString = Console.ReadLine();

            int lengthInt = int.Parse(lengthString);

            if (unitString == "M" || unitString == "m")
            {
                Console.WriteLine(lengthString + "m " + "is " + (int)(lengthInt * 3.2808399) + "f.");
            }
            else if (unitString == "F" || unitString == "f")
            {
                Console.WriteLine(lengthString + "f " + "is " + (int)(lengthInt * 0.3048) + "m.");
            }
            else
            {
                Console.WriteLine("Invalid data.");
            }
        }
    }
}
