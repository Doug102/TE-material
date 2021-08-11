using System;
using System.Collections.Generic;

namespace CollectionsPart2Lecture
{
    public class CollectionsPart2Lecture
	{
        static void Main(string[] args)
        {
			Console.WriteLine("####################");
			Console.WriteLine("       DICTIONARIES");
			Console.WriteLine("####################");
			Console.WriteLine();

			Dictionary<string, int> petAges = new Dictionary<string, int>();

			petAges["prim"] = 7;
			petAges.Add("gabe", 7);
			petAges.Add("penny", 7);
			petAges.Add("bella", 4);

			foreach (string name in petAges.Keys)
            {
                Console.WriteLine(name);
            }
			int sum = 0;
			foreach (int age in petAges.Values)
            {
				sum += age;
            }

            Console.WriteLine("Average age is: " + (double)sum / petAges.Count);

			while (true)
			{
                Console.WriteLine();
				foreach (KeyValuePair<string, int> kvp in petAges)
				{
					Console.WriteLine(kvp.Key + " is age " + kvp.Value);
				}

				Console.Write("Please enter a pet name: ");
				string userInput = Console.ReadLine();

                Console.Write("Please enter a pet age, 0 to leave unchanged: ");
				string petAge = Console.ReadLine();
				int age = int.Parse(petAge);


                
				if (petAges.ContainsKey(userInput.ToLower()))
				{
                    Console.WriteLine();
					Console.WriteLine(userInput + " is age " + petAges[userInput.ToLower()]);

					if (age != 0)
                    {
						petAges[userInput.ToLower()] = age;
                    }
				}
				else
                {
                    Console.WriteLine("Key not found, please try again.");
                }
			}



		}
	}
}
