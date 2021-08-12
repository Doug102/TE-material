using System;
using System.Collections.Generic;

namespace AuctionApp
{
    public class ConsoleService
    {

        public void Run()
        {
            Console.WriteLine("Welcome to Online Auctions! Please make a selection:");
            MenuSelection();
        }

        private void MenuSelection()
        {
            APIService api = new APIService();
            int menuSelection = -1;
            while (menuSelection != 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Welcome to Online Auctions! Please make a selection: ");
                Console.WriteLine("1: List all auctions");
                Console.WriteLine("2: List details for specific auction");
                Console.WriteLine("3: Find auctions with a specific term in the title");
                Console.WriteLine("4: Find auctions below a specified price");
                Console.WriteLine("5: Create a new auction");
                Console.WriteLine("6: Modify an auction");
                Console.WriteLine("7: Delete an auction");
                Console.WriteLine("0: Exit");
                Console.WriteLine("---------");
                Console.Write("Please choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out menuSelection))
                {
                    Console.WriteLine("Invalid input. Please enter only a number.");
                }
                else if (menuSelection == 1)
                {
                    try
                    {
                        List<Auction> auctions = api.GetAllAuctions();
                        if (auctions != null)
                        {
                            PrintAuctions(auctions);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (menuSelection == 2)
                {
                    List<Auction> auctions = api.GetAllAuctions();
                    if (auctions != null && auctions.Count > 0)
                    {
                        int auctionId = PromptForAuctionID(auctions, "get the details");
                        if (auctionId != 0)
                        {
                            try
                            {
                                Auction auction = api.GetDetailsForAuction(auctionId);
                                if (auction != null)
                                {
                                    PrintAuction(auction);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                }
                else if (menuSelection == 3)
                {
                    string searchTitle = PromptForSearchTitle();
                    if (!string.IsNullOrWhiteSpace(searchTitle))
                    {
                        try
                        {
                            List<Auction> auctions = api.GetAuctionsSearchTitle(searchTitle);
                            if (auctions != null)
                            {
                                PrintAuctions(auctions);
                            }
                            else
                            {
                                Console.WriteLine("No auction found for search title: " + searchTitle);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                else if (menuSelection == 4)
                {
                    double maxPrice = PromptForMaxPrice();
                    if (maxPrice > 0)
                    {
                        try
                        {
                            List<Auction> auctions = api.GetAuctionsSearchPrice(maxPrice);
                            if (auctions != null)
                            {
                                PrintAuctions(auctions);
                            }
                            else
                            {
                                Console.WriteLine("No auctions found under max price: " + maxPrice.ToString("C"));
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                else if (menuSelection == 5)
                {
                    string newAuctionString = PromptForAuctionData();
                    Auction auctionToAdd = new Auction(newAuctionString);
                    if (auctionToAdd.IsValid)
                    {
                        try
                        {
                            Auction addedAuction = api.AddAuction(auctionToAdd);
                            if (addedAuction != null)
                            {
                                Console.WriteLine("Auction successfully added.");
                            }
                            else
                            {
                                Console.WriteLine("Auction not added.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                else if (menuSelection == 6)
                {
                    // Update an existing auction
                    try
                    {
                        List<Auction> auctions = api.GetAllAuctions();
                        if (auctions != null)
                        {
                            int auctionId = PromptForAuctionID(auctions, "update");
                            Auction oldAuction = api.GetDetailsForAuction(auctionId);
                            if (oldAuction != null)
                            {
                                string updatedAuctionString = PromptForAuctionData(oldAuction);
                                Auction auctionToUpdate = new Auction(updatedAuctionString);
                                if (auctionToUpdate.IsValid)
                                {
                                    Auction updatedAuction = api.UpdateAuction(auctionToUpdate);
                                    if (updatedAuction != null)
                                    {
                                        Console.WriteLine("Auction successfully updated.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Auction not updated.");
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (menuSelection == 7)
                {
                    // Delete auction
                    try
                    {
                        List<Auction> auctions = api.GetAllAuctions();
                        if (auctions != null)
                        {
                            int auctionId = PromptForAuctionID(auctions, "delete");
                            bool deleteSuccess = api.DeleteAuction(auctionId);
                            if (deleteSuccess)
                            {
                                Console.WriteLine("Auction successfully deleted.");
                            }
                            else
                            {
                                Console.WriteLine("Auction not deleted.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                }
            }
        }

        //Print methods

        private void PrintAuctions(List<Auction> auctions)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Auctions");
            Console.WriteLine("--------------------------------------------");
            foreach (Auction auction in auctions)
            {
                Console.WriteLine($"{auction.Id} : {auction.Title} : {auction.User} : {auction.CurrentBid:C}");
            }
        }

        private void PrintAuction(Auction auction)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Auction Details");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(" Id: " + auction.Id);
            Console.WriteLine(" Name: " + auction.Title);
            Console.WriteLine(" Description: " + auction.Description);
            Console.WriteLine(" User: " + auction.User);
            Console.WriteLine(" Current Bid: " + auction.CurrentBid.ToString("C"));
        }

        //Prompt methods

        private int PromptForAuctionID(List<Auction> auctions, string action)
        {
            PrintAuctions(auctions);
            Console.WriteLine("");
            Console.Write("Please enter an auction ID to " + action + ": ");
            if (!int.TryParse(Console.ReadLine(), out int auctionId))
            {
                Console.WriteLine("Invalid input. Only input a number.");
                return 0;
            }
            else
            {
                return auctionId;
            }
        }

        private string PromptForSearchTitle()
        {
            Console.Write("Please enter a title to search for: ");
            string searchTitle = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(searchTitle))
            {
                Console.WriteLine("Invalid input. Please enter some text.");
                return null;
            }
            else
            {
                return searchTitle;
            }
        }

        private double PromptForMaxPrice()
        {
            Console.Write("Please enter a max price to search for: ");
            if (!double.TryParse(Console.ReadLine(), out double maxPrice))
            {
                Console.WriteLine("Invalid input. Only input a number.");
                return 0;
            }
            else
            {
                return maxPrice;
            }
        }

        private string PromptForAuctionData(Auction auction = null)
        {
            string auctionString;
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Enter auction data as a comma separated list containing:");
            Console.WriteLine("Title, Description, User, Current Bid");
            if (auction != null)
            {
                PrintAuction(auction);
            }
            else
            {
                Console.WriteLine("Example: Dragon Plush, Not a real dragon, Bernice, 19.50");
            }
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("");
            auctionString = Console.ReadLine();
            if (auction != null && auction.Id.HasValue)
            {
                auctionString += "," + auction.Id.Value;
            }
            return auctionString;
        }
    }
}
