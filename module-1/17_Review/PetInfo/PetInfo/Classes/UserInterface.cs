using System;
using System.Collections.Generic;
using System.IO;

namespace PetInfo
{
    public class UserInterface
    {
        private PetWorks petWorks;

        public UserInterface()
        {
            try
            {
                petWorks = new PetWorks();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error starting UserInterface: " + ex.Message);
                Console.ReadLine();
                Environment.Exit(0);
            }
        }

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
            Console.WriteLine();
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

            bool result = false;

            try
            {
                result = petWorks.AddPet(id, name, type, breed);
            }
            catch(IOException ex)
            {
                Console.WriteLine("Error adding pet: " + ex.Message);
                return;
            }

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
            //todo add try/catch
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

            bool result = false;
                
            try
            {
                result = petWorks.DeletePet(id);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error deleting pet: " + ex.Message);
                return;
            }

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
