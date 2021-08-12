using System;

namespace TempConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter the temperature:");
            string tempString = Console.ReadLine();
            Console.Write("Is the temperature in (C)elsius, or (F)ahrenheit?");
            string degreeString = Console.ReadLine();

            int tempInt = int.Parse(tempString);

            if (degreeString == "F" || degreeString == "f")
            {
                Console.WriteLine(tempString + "F " + "is " + (int)((tempInt - 32) / 1.8) + "C.");
            }
            else if (degreeString == "C" || degreeString == "c")
            {
                Console.WriteLine(tempString + "C " + "is " + (int)((tempInt * 1.8) + 32) + "F.");
            }
            else
            {
                Console.WriteLine("Invalid data.");
            }

        }
    }
}
