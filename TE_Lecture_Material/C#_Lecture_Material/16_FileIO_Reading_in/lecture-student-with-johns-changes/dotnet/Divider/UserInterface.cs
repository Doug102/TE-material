using System;
using System.Collections.Generic;
using System.Text;

namespace Divider
{
    class UserInterface
    {
        public void Runner()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter number to be divided: ");
                    decimal dividend = decimal.Parse(Console.ReadLine());

                    Console.Write("Enter the number to divide by: ");
                    decimal devisor = decimal.Parse(Console.ReadLine());

                    decimal quotient = dividend / devisor;
                    Console.WriteLine("Result is: " + quotient);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message + " Please try again.");
                }
                catch(DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message + " Please try again.");
                }

                Console.WriteLine();
            }
        }
    }
}
