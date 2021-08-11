using System;
using System.Collections.Generic;
using System.Text;

namespace PetInfo
{
    public class UserInterface
    {
        private List<Pet> pets = new List<Pet>();

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
                    case "4":
                        PetDetails();
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
            Console.WriteLine("4 - Detailed info");
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

            Pet pet;

            if (type == "cat")
            {
                 pet = new Cat(id, name, type, breed);
            }
            else if (type == "dog")
            {
                 pet = new Dog(id, name, type, breed);
            }
            else if (type == "parrot")
            {
                 pet = new Parrot(id, name, type, breed);
            }
            else
            {
                 pet = new Pet(id, name, type, breed);
            }

            

            pets.Add(pet);
        }

        private void ListPets()
        {
            foreach (Pet pet in pets)
            {
                //Console.WriteLine(pet.ToString());

                Console.WriteLine(pet.Id + " - " + pet.Name);
            }
        }

        private void DeleteAPet()
        {
            Console.Write("Please enter a pet Id (5, 23, etc.): ");
            int id = int.Parse(Console.ReadLine());

            int i = 0;

            for (i = 0; i < pets.Count; i++)
            {
                if (pets[i].Id == id)
                {
                    break;
                }
            }

            if (i < pets.Count)
            {
                pets.RemoveAt(i);
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }
        private void PetDetails()
        {
            Console.Write("Please enter a pet Id (5, 23, etc.): ");
            int id = int.Parse(Console.ReadLine());

            int index = -1;
            
            for (int i =0; i < pets.Count; i++)
            {
                if (pets[i].Id == id)
                {
                    index = i;
                    break;
                }
            }

            if (index > -1)
            {
                Console.WriteLine(pets[index].Name);
                Console.WriteLine(pets[index].Type);
                Console.WriteLine(pets[index].LastVetVisit);
                Console.WriteLine(pets[index].NextVetVisit());

            }
            else
            {
                Console.WriteLine("Pet not found");
            }

        }
    }
}
