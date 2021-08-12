using System;
using System.Collections.Generic;

namespace HotelApp
{
    public class ConsoleService
    {
        private static readonly APIService apiService = new APIService("http://localhost:3000/");

        public void Run()
        {
            Console.WriteLine("Welcome to Online Hotels! Please make a selection:");
            MenuSelection();
        }

        private void MenuSelection()
        {
            while (true)
            {
                DisplayMenu();
                string response = Console.ReadLine();


                switch (response)
                {
                    case "1":
                        ListHotels();
                        break;

                    case "2":
                        ListReservations();
                        break;

                    case "3":
                        CreateReservation();
                        break;

                    case "4":
                        UpdateReservation();
                        break;

                    case "5":
                        DeleteReservation();
                        break;

                    case "0":
                        Console.WriteLine("Goodbye!");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Please make a valid selection");
                        break;
                }
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("Menu:");
            Console.WriteLine("1: List Hotels");
            Console.WriteLine("2: List Reservations for Hotel");
            Console.WriteLine("3: Create new Reservation for Hotel");
            Console.WriteLine("4: Update existing Reservation for Hotel");
            Console.WriteLine("5: Delete Reservation");
            Console.WriteLine("0: Exit");
            Console.WriteLine("---------");
            Console.Write("Please choose an option: ");
        }

        private void ListHotels()
        {
            try
            {
                List<Hotel> hotels = apiService.GetHotels();
                if (hotels != null && hotels.Count > 0)
                {
                    PrintHotels(hotels);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ListReservations()
        {
            try
            {
                List<Hotel> hotels = apiService.GetHotels();
                if (hotels != null && hotels.Count > 0)
                {
                    int hotelId = PromptForHotelID(hotels, "list reservations");
                    if (hotelId != 0)
                    {
                        List<Reservation> reservations = apiService.GetReservations(hotelId);
                        if (reservations != null)
                        {
                            PrintReservations(reservations, hotelId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void CreateReservation()
        {
            // Create new reservation
            string newReservationString = PromptForReservationData();
            Reservation reservationToAdd = new Reservation(newReservationString);

            if (reservationToAdd.IsValid)
            {
                try
                {
                    Reservation addedReservation = apiService.AddReservation(reservationToAdd);
                    if (addedReservation != null)
                    {
                        Console.WriteLine("Reservation successfully added.");
                    }
                    else
                    {
                        Console.WriteLine("Reservation not added.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void UpdateReservation()
        {
            // Update an existing reservation
            try
            {
                List<Reservation> reservations = apiService.GetReservations();
                if (reservations != null)
                {
                    int reservationId = PromptForReservationID(reservations, "update");
                    Reservation oldReservation = apiService.GetReservation(reservationId);
                    if (oldReservation != null)
                    {
                        string updReservationString = PromptForReservationData(oldReservation);
                        Reservation reservationToUpdate = new Reservation(updReservationString);

                        if (reservationToUpdate.IsValid)
                        {
                            Reservation updatedReservation = apiService.UpdateReservation(reservationToUpdate);
                            if (updatedReservation != null)
                            {
                                Console.WriteLine("Reservation successfully updated.");
                            }
                            else
                            {
                                Console.WriteLine("Reservation not updated.");
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

        private void DeleteReservation()
        {
            // Delete reservation
            try
            {
                List<Reservation> reservations = apiService.GetReservations();
                if (reservations != null)
                {
                    int reservationId = PromptForReservationID(reservations, "delete");

                    bool deleteSuccess = apiService.DeleteReservation(reservationId);
                    if (deleteSuccess)
                    {
                        Console.WriteLine("Reservation successfully deleted.");
                    }
                    else
                    {
                        Console.WriteLine("Reservation not deleted.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Print methods

        private void PrintHotels(List<Hotel> hotels)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Hotels");
            Console.WriteLine("--------------------------------------------");
            foreach (Hotel hotel in hotels)
            {
                Console.WriteLine(hotel.Id + ": " + hotel.Name);
            }
        }

        private void PrintHotel(Hotel hotel)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Hotel Details");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(" Id: " + hotel.Id);
            Console.WriteLine(" Name: " + hotel.Name);
            Console.WriteLine(" Stars: " + hotel.Stars);
            Console.WriteLine(" Rooms Available: " + hotel.RoomsAvailable);
            Console.WriteLine(" Cover Image: " + hotel.CoverImage);
        }

        private void PrintReservations(List<Reservation> reservations, int hotelId = -1)
        {
            string msg = hotelId == -1 ? "All Reservations" : "Reservations for hotel: " + hotelId;
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(msg);
            Console.WriteLine("--------------------------------------------");
            if (reservations.Count > 0)
            {
                foreach (Reservation reservation in reservations)
                {
                    PrintReservationDetails(reservation);
                }
            }
            else
            {
                Console.WriteLine("There are no reservations for hotel: " + hotelId);
            }
        }

        private void PrintReservationDetails(Reservation reservation)
        {
            Console.WriteLine(" Id: " + reservation.Id);
            Console.WriteLine(" Hotel ID: " + reservation.HotelId);
            Console.WriteLine(" Name: " + reservation.FullName);
            Console.WriteLine(" Check-in Date: " + reservation.CheckinDate);
            Console.WriteLine(" Check-out Date: " + reservation.CheckoutDate);
            Console.WriteLine(" Guests: " + reservation.Guests);
            Console.WriteLine("");
        }

        //Prompt methods

        private int PromptForHotelID(List<Hotel> hotels, string action)
        {
            PrintHotels(hotels);
            Console.WriteLine("");
            Console.Write("Please enter a hotel ID to " + action + ": ");
            if (!int.TryParse(Console.ReadLine(), out int hotelId))
            {
                Console.WriteLine("Invalid input. Only input a number.");
                return 0;
            }
            else
            {
                return hotelId;
            }
        }

        private int PromptForReservationID(List<Reservation> reservations, string action)
        {
            PrintReservations(reservations);
            Console.WriteLine("");
            Console.Write("Please enter a reservation ID to " + action + ": ");
            if (!int.TryParse(Console.ReadLine(), out int reservationId))
            {
                Console.WriteLine("Invalid input. Only input a number.");
                return 0;
            }
            else
            {
                return reservationId;
            }
        }

        private string PromptForReservationData(Reservation reservation = null)
        {
            string reservationString;
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Enter reservation data as a comma separated list containing:");
            Console.WriteLine("Hotel ID, Full Name, Checkin Date, Checkout Date, Number of Guests");
            if (reservation != null)
            {
                PrintReservationDetails(reservation);
            }
            else
            {
                Console.WriteLine("Example: 1, John Smith, 10/10/2020, 10/14/2020, 2");
            }
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("");
            reservationString = Console.ReadLine();
            if (reservation != null && reservation.Id.HasValue)
            {
                reservationString += "," + reservation.Id.Value;
            }
            return reservationString;
        }
    }
}
