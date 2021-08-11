using System;
using System.Collections.Generic;

namespace CollectionsPart1Lecture
{
    public class CollectionsPart1Lecture
    {
        static void Main(string[] args)
        {
            Console.WriteLine("####################");
            Console.WriteLine("       LISTS");
            Console.WriteLine("####################");

            List<string> petNames = new List<string>();
            petNames.Add("Prim");
            petNames.Add("Gabe");
            petNames.Add("Penny");
            petNames.Add("Bella");

            Console.WriteLine("####################");
            Console.WriteLine("Lists are ordered");
            Console.WriteLine("####################");

            foreach (string pet in petNames)
            {
                Console.WriteLine(pet);
            }

            Console.WriteLine("####################");
            Console.WriteLine("Lists allow duplicates");
            Console.WriteLine("####################");

            petNames.Add("Bella");
            foreach (string pet in petNames)
            {
                Console.WriteLine(pet);
            }

            Console.WriteLine("####################");
            Console.WriteLine("Lists allow elements to be inserted in the middle");
            Console.WriteLine("####################");

            petNames.Insert(1, "Goldfish 1");
            foreach (string pet in petNames)
            {
                Console.WriteLine(pet);
            }

            Console.WriteLine("####################");
            Console.WriteLine("Lists allow elements to be removed by index");
            Console.WriteLine("####################");

            petNames.RemoveAt(petNames.Count - 1);
            foreach (string pet in petNames)
            {
                Console.WriteLine(pet);
            }

            Console.WriteLine("####################");
            Console.WriteLine("Find out if something is already in the List");
            Console.WriteLine("####################");

            Console.WriteLine("Contains Goldfish 2? " + petNames.Contains("Goldfish 2"));

            Console.WriteLine("####################");
            Console.WriteLine("Find index of item in List");
            Console.WriteLine("####################");

            Console.WriteLine("Index of Goldfish 2: " + petNames.IndexOf("Goldfish 2"));

            Console.WriteLine("####################");
            Console.WriteLine("Lists can be turned into an array");
            Console.WriteLine("####################");

            string[] result = petNames.ToArray();
            foreach (string pet in result)
            {
                Console.WriteLine(pet);
            }

            Console.WriteLine(petNames);
            Console.WriteLine(result);

            Console.WriteLine("####################");
            Console.WriteLine("Lists can be sorted");
            Console.WriteLine("####################");

            petNames.Sort();
            foreach (string pet in petNames)
            {
                Console.WriteLine(pet);
            }

            Console.WriteLine("####################");
            Console.WriteLine("Lists can be reversed too");
            Console.WriteLine("####################");

            petNames.Reverse();
            foreach (string pet in petNames)
            {
                Console.WriteLine(pet);
            }

            Console.WriteLine("####################");
            Console.WriteLine("       FOREACH");
            Console.WriteLine("####################");
            Console.WriteLine();

            //petNames.AddRange();


            Console.WriteLine("####################");
            Console.WriteLine("       QUEUE");
            Console.WriteLine("####################");
            Console.WriteLine();

            Queue<string> pets = new Queue<string>();
            pets.Enqueue("Bella");
            pets.Enqueue("Prim");
            pets.Enqueue("Roscoe");

            while(pets.Count > 0)
            {
                Console.WriteLine(pets.Dequeue());
            }

            Console.WriteLine("Size of pets after loop is " + pets.Count);

            Console.WriteLine("####################");
            Console.WriteLine("       STACK");
            Console.WriteLine("####################");
            Console.WriteLine();

            Stack<string> thesePets = new Stack<string>();
            thesePets.Push("Bella");
            thesePets.Push("Prim");
            thesePets.Push("Roscoe");

            while(thesePets.Count > 0)
            {
                Console.WriteLine(thesePets.Pop());
            }

            Console.WriteLine("####################");
            Console.WriteLine("       SWITCH/CASE");
            Console.WriteLine("####################");
            Console.WriteLine();


            while (true)
            {
                Console.Write("Please enter a pet name: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "Bella":
                        Console.WriteLine("You selected a dog.");
                        break;
                    case "Prim":
                        Console.WriteLine("You selected a cat.");
                        break;
                    case "Roscoe":
                        Console.WriteLine("You selected a wild cat.");
                        break;
                    default:
                        Console.WriteLine("Please make a valid selection.");
                        break;
                }
            }
        }
    }
}
