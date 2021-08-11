using PetInfoClient.APIServices;
using PetInfoClient.Models;
using System;
using System.Collections.Generic;

namespace WorldClient
{
    public class ConsoleService
    {

        private readonly PetAPIService petAPIService = new PetAPIService();
        private readonly CustomerAPIService customerAPIService = new CustomerAPIService();

        public void Run()
        {
            PrintHeader();
            PrintMenu();

            bool done = false;

            while (!done)
            {

                string userInput = Console.ReadLine();

                switch (userInput)
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
                        continue;

                    default:
                        Console.WriteLine("Please enter a valid choice.");
                        break;
                }

                PrintMenu();
            }
        }

        private void PrintHeader()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(@":'########::'########:'########:'####:'##::: ##:'########::'#######:: ");
            Console.WriteLine(@": ##.... ##: ##.....::... ##..::. ##:: ###:: ##: ##.....::'##.... ##: ");
            Console.WriteLine(@": ##:::: ##: ##:::::::::: ##::::: ##:: ####: ##: ##::::::: ##:::: ##: ");
            Console.WriteLine(@": ########:: ######:::::: ##::::: ##:: ## ## ##: ######::: ##:::: ##: ");
            Console.WriteLine(@": ##.....::: ##...::::::: ##::::: ##:: ##. ####: ##...:::: ##:::: ##: ");
            Console.WriteLine(@": ##:::::::: ##:::::::::: ##::::: ##:: ##:. ###: ##::::::: ##:::: ##: ");
            Console.WriteLine(@": ##:::::::: ########:::: ##::::'####: ##::. ##: ##:::::::. #######:: ");
            Console.WriteLine(@"..:::::::::........:::::..:::::....::..::::..::..:::::::::.......::: ");
            // from: http://www.network-science.de/ascii/ with banner3-D
        }

        private void PrintMenu()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Main-Menu Type in a command");
            Console.WriteLine(" 1 - Add a pet");
            Console.WriteLine(" 2 - Delete a pet");
            Console.WriteLine(" 3 - List pets");
            Console.WriteLine(" Q - Quit");
        }





        private void DeleteAPet()
        {
            try
            {
                Console.WriteLine("Please select the pet to delete.");
                ListPets();
                Console.Write("Please enter a pet number: ");
                int petNumber = int.Parse(Console.ReadLine());
                bool result = petAPIService.DeletePet(petNumber);
                if (result)
                {
                    Console.WriteLine("Deleted.");
                }
                else
                {
                    Console.WriteLine("ERROR: Unable to delete.");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine();
                Console.WriteLine("Unable to list pets: " + ex.Message);
            }

        }

        private void ListPets()
        {
            try
            {
                List<Pet> pets = petAPIService.GetPets();

                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("The pets are:");
                foreach (Pet pet in pets)
                {
                    Console.WriteLine(pet);
                }
                Console.WriteLine();
            }
            catch (Exception ex)
            {

                Console.WriteLine();
                Console.WriteLine("Unable to list pets: " + ex.Message);
            }
        }

        private void AddAPet()
        {
            try
            {
                Pet temp = new Pet();

                Console.Write("Enter name: ");
                temp.Name = Console.ReadLine();

                Console.Write("Enter type (dog, cat, parrot, etc.): ");
                temp.Type = Console.ReadLine();

                Console.Write("Enter breed (Chow, German Shepard, DSH, etc.): ");
                temp.Breed = Console.ReadLine();

                ListOwners();

                Console.Write("Enter Owner Id (1001): ");
                temp.Owner = int.Parse(Console.ReadLine());

                bool answer = petAPIService.AddPet(temp);

                if (answer == true)
                {
                    Console.WriteLine("added a pet.");
                }
                else
                {
                    Console.WriteLine("Unable to add a pet");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("Unable to list pets: " + ex.Message);
            }
        }

        private void ListOwners()
        {
            Console.WriteLine("John - 1000");
            Console.WriteLine("Lisa - 1001");
            Console.WriteLine();
            //List<Customer> customers = customerAPIService.GetCustomers();

            //Console.WriteLine();
            //Console.WriteLine();

            //Console.WriteLine("The owners are:");
            //foreach (Customer customer in customers)
            //{
            //    Console.WriteLine(customer);
            //}
            //Console.WriteLine();
        }

    }
}




