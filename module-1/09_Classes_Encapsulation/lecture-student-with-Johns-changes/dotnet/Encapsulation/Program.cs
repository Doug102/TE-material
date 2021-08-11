using System;
using System.Collections.Generic;

namespace Encapsulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<string> myList = new List<string>();

            Television myTelevision = new Television();
            myTelevision.SerialNumber = 1234556;

            Console.WriteLine(myTelevision.SerialNumber);

            List<string> connectors = myTelevision.availablePowerConnectors;

            myTelevision.availablePowerConnectors.Add("SA");

            Television yourTelevision = new Television();


            //yourTelevision.IsULListed = true;

            Console.WriteLine(yourTelevision.IsULListed);

            yourTelevision.Volume = 7;

            Console.WriteLine("Volume: " + yourTelevision.Volume);







        }

    }
}
