using System;
using System.Collections.Generic;

namespace PetInfo
{
    public class UserInterface
    {
        private PetWorks petWorks = new PetWorks();

        public void UserInput()
        {

            bool done = false;

            while (!done)
            {
                DisplayMenu();

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddAPet();
                        break;
                    case "2":
                        DeleteAPet();
                        break;
                    case "3":
                        ListPets();
                        break;
                    case "q":
                    case "Q":
                        done = true;
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please enter a valid choice.");
                        break;
                }
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine("Please make a selection:");
            Console.WriteLine("1 - Add a pet");
            Console.WriteLine("2 - Delete a pet");
            Console.WriteLine("3 - List pets");
            Console.WriteLine("Q - Quit the program");
        }

        private void AddAPet()
        {
            Console.Write("Please enter a pet Id (5, 23, etc.): ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter pet name: ");
            string name = Console.ReadLine();


            Console.Write("Enter pet type (cat, dog, etc.): ");
            string type = Console.ReadLine();


            Console.Write("Enter pet breed (German Shapard, DSH, etc.): ");
            string breed = Console.ReadLine();

            bool result = petWorks.AddPet(id, name, type, breed);

            if(result)
            {
                Console.WriteLine("Pet added.");
            }
            else
            {
                Console.WriteLine("Failed to add pet.");
            }

        }

        private void ListPets()
        {
            Pet[] result = petWorks.GetPets();

            foreach (Pet pet in result)
            {
                Console.WriteLine(pet.ToString());
            }
        }

        private void DeleteAPet()
        {
            Console.Write("Please enter a pet Id (5, 23, etc.): ");
            int id = int.Parse(Console.ReadLine());

            bool result = petWorks.DeletePet(id);

            if (result)
            {
                Console.WriteLine("Pet deleted.");
            }
            else
            {
                Console.WriteLine("Failed to delete pet.");
            }
        }
    }
}
