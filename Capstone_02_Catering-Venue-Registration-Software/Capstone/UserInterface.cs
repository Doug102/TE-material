using Capstone.DAL;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace Capstone
{
    public class UserInterface
    {
        //ALL Console.ReadLine and WriteLine in this class
        //NONE in any other class

        private string connectionString;
        private VenueDAO venueDAO;

        public UserInterface(string connectionString)
        {
            this.connectionString = connectionString;
            venueDAO = new VenueDAO(connectionString);
        }

        public void Run()
        {
            bool done = false;
            while (!done)
            {

                DisplayMenu();
                string userResponse = Console.ReadLine();

                try
                {
                    switch (userResponse)
                    {
                        case "1":
                            VenueMenu();
                            break;
                        //case "d":
                        //case "D":
                        //    DisplayReservations();
                        //    break;
                        case "q":
                        case "Q":
                            done = true;
                            break;
                        default:
                            Console.WriteLine("Please Select Valid Response");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }

        public void DisplayMenu()
        {
            Console.WriteLine("Please Choose From The Following Choices:");
            Console.WriteLine("1) List Venues");
            //Console.WriteLine("D) Display Reservations");
            Console.WriteLine("Q) Quit Program");
        }


        public void VenueMenu()
        {

            bool done = false;
            List<Venue> venueList = venueDAO.GetVenueList();
            while (!done)
            {
                VenueList();
                string userResponse = Console.ReadLine();
                try
                {
                    if (userResponse.ToUpper() == "R")
                    {
                        done = true;
                        break;
                    }
                    else if (int.Parse(userResponse) > -1)
                    {
                        for (int i = 0; i < venueList.Count; i++)
                        {
                            if (i == int.Parse(userResponse) - 1)
                            {
                               
                                Venue venueChoice = venueDAO.GetVenueDetails(userResponse);
                                VenueDetails(venueChoice);
                                Console.WriteLine();
                            }
                        }
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Please enter a valid response");
                }
            }

        }


        public void VenueList()
        {
            Console.WriteLine();
            Console.WriteLine("Which venue would you like to view?");
            List<Venue> venueList = venueDAO.GetVenueList();
            int count = 0;
            foreach (Venue venue in venueList)
            {
                count++;
                Console.WriteLine(count + ") " + venue.Name);
            }

            Console.WriteLine("R) Return To Previous Screen");

        }

        public void VenueDetails(Venue venue)
        {
            Console.WriteLine(venue.Name);
            Console.WriteLine($"Location: {venue.CityName}, {venue.StateAbbreviation}");
            Console.WriteLine($"Categories: {venue.Category}");
            Console.WriteLine();
            Console.WriteLine(venue.Description);
            int venueId = venue.VenueId;
            Console.WriteLine();
            VenueDetailsMenu(venueId);
        }
        public void VenueDetailsMenu(int venueId)
        {
            bool done = false;
            while (!done)
            {
                DisplayVenueDetailsMenu(venueId);
                string userResponse = Console.ReadLine();
                try
                {
                    switch (userResponse)
                    {
                        case "1":
                            VenueSpaceList(venueId);
                            break;
                        case "2":
                            ReservationInfo(venueId);
                            break;
                        case "R":
                        case "r":
                            done = true;
                            break;
                        default:
                            Console.WriteLine("Please Select Valid Response");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }



        public void VenueSpaceList(int venueId)
        {
            Console.WriteLine();
            Console.WriteLine("{0,-6} {1,-30} {2,-10} {3,-10} {4,-15} {5,-10}", "  ", "Name", "Open", "Close", "Daily Rate", "Max Occup.");
            int count = 0;
            List<Space> spaces = venueDAO.GetVenueSpaceList(venueId);
            foreach (Space space in spaces)
            {
                count++;
                Console.WriteLine("#{0,-5} {1,-30} {2,-10} {3,-10} ${4,-15} {5,-10}", count, space.Name, space.OpenFromAbb, space.OpenToAbb, space.DailyRate, space.MaxOccupancy);
            }
            Console.WriteLine();
            SpacesListMenu(spaces, venueId);
        }



        public void ReservationInfo(int venueId)
        {
            try
            {
                Console.WriteLine();
                Console.Write("When do you need the space? (ex. 10/20/2021) ");
                string startDate = Console.ReadLine();
                Console.Write("How many days will you need the space? ");
                int days = int.Parse(Console.ReadLine());
                string endDate = Convert.ToDateTime(startDate).AddDays(days).ToShortDateString();
                Console.Write("How many people will be in attendance? ");
                int attendance = int.Parse(Console.ReadLine());
                DisplayAvailableSpaces(venueId, startDate, days, attendance);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public void DisplayAvailableSpaces(int venueId, string startDate, int days, int attendance)
        {
            List<Space> spaces = venueDAO.GetAvailableSpaces(venueId, startDate, days, attendance);
            foreach (Space space in spaces)
            {
                Console.WriteLine(space.SpaceId + " - " + space.Name + " - $" + space.DailyRate + " - " + space.MaxOccupancy + " - " + space.IsAccessible + " - $" + space.TotalCost);
            }
            BookReservation(spaces, venueId, startDate, days, attendance);
        }


        public void DisplayVenueDetailsMenu(int venueId)
        {
            Console.WriteLine("What would you like to do next?");
            Console.WriteLine("1) View Venue Spaces");
            Console.WriteLine("2) Reserve A Space");
            Console.WriteLine("R) Return To Previous Screen");
        }


        public void SpacesListMenu(List<Space> spaces, int venueId)
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine();
                DisplaySpaceListMenu();
                string userinput = Console.ReadLine();
                try
                {
                    switch (userinput)
                    {
                        case "1":
                            ReservationInfo(venueId);
                            break;
                        case "r":
                        case "R":
                            done = true;
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void DisplaySpaceListMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to do next?");
            Console.WriteLine("1) Reserve A Space");
            Console.WriteLine("R) Return To Previous Screen");
        }


        public void BookReservation(List<Space> spaces, int venueId, string startDate, int days, int attendance)
        {
            BookReservationMenu(spaces, venueId, startDate, days, attendance);
        }


        public void BookReservationMenu(List<Space> spaces, int venueId, string startDate, int days, int attendance)
        {
            bool done = false;
            Space reservationSpace;
            while (!done)
            {
                try
                {
                    Console.WriteLine();
                    Console.Write("Please Enter Space Id (0 to cancel): ");
                    string spaceId = Console.ReadLine();
                    if (spaceId == "0")
                    {
                        done = true;
                        break;
                    }
                    Console.Write("Please Enter Reservation Name: ");
                    string reservationName = Console.ReadLine();

                    for (int i = 0; i < spaces.Count; i++)
                    {
                        if (spaces[i].SpaceId == int.Parse(spaceId))
                        {
                            reservationSpace = spaces[i];
                            ReservationConfirmation(reservationSpace, venueId, startDate, days, attendance, reservationName);
                            done = true;
                        }
                    }

                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public void ReservationConfirmation(Space space, int venueId, string startDate, int days, int attendance, string reservationName)
        {
            int reservation = venueDAO.AddReservation(space, startDate, days, attendance, reservationName);
            if (reservation > 0)
            {
                Reservation reservationConfirmation = venueDAO.GetReservationConfirmation(reservation);
                DisplayConfirmation(reservationConfirmation);


            }
        }

        public void DisplayConfirmation(Reservation reservation)
        {
            Console.WriteLine($"Confirmation #: {reservation.ReservationId}");
            Console.WriteLine($"Venue: {reservation.VenueName}");
            Console.WriteLine($"Space: {reservation.SpaceName}");
            Console.WriteLine($"Reserved For: {reservation.ReservedFor}");
            Console.WriteLine($"Attendees: {reservation.NumberOfAttendees}");
            Console.WriteLine($"Arrival Date: {reservation.ReservedFrom}");
            Console.WriteLine($"Depart Date: {reservation.ReservedTo}");
            Console.WriteLine($"Total Cost: ${reservation.TotalCost}");
            Console.WriteLine();
        }

        //Bonus Methods
        //public void DisplayReservations()
        //{
        //    List<Reservation> reservations;
        //    Console.WriteLine("The following reservations are scheduled for the next 30 days:");
        //    Console.WriteLine();
        //    Console.WriteLine("{0,-30} {1,-20} {2, -20} {3, -15} {4, -15}", "Venue", "Space", "Reserved For", "From", "To");
        //    //foreach (Reservation reservation in reservations)
        //    //{
        //    //    Console.WriteLine();
        //    //}
        //Console.WriteLine();
        //}
    }
}
