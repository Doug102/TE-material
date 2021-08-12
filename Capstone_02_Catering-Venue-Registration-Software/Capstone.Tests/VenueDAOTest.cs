using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Capstone.Tests
{
    [TestClass]
    public class VenueDAOTest : ParentTest
    {
        [TestMethod]
        public void Can_create_Venue_object()
        {
            //Arrange

            //Act

            //Assert
            Assert.IsNotNull(venueDAO);

        }

        [TestMethod]

        public void GetVenueListTest()
        {
            List<Venue> venues = venueDAO.GetVenueList();

            Assert.IsNotNull(venues);
        }

        [TestMethod]
        [DataRow("1")]

        public void GetVenueDetails1(string userInput)
        {
            Venue venue = venueDAO.GetVenueDetails(userInput);

            Assert.AreEqual(6, venue.VenueId);
            Assert.AreEqual("Blue Nomad Outpost", venue.Name);
            Assert.AreEqual("Yepford", venue.CityName);
            Assert.AreEqual("Family Friendly, Historic", venue.Category);
            Assert.AreEqual("IA", venue.StateAbbreviation);

        }

        [TestMethod]
        [DataRow("6")]

        public void GetVenueDetails6(string userinput)
        {
            Venue venue = venueDAO.GetVenueDetails(userinput);

            Assert.AreEqual(7, venue.VenueId);
            Assert.AreEqual("Howling Pour Lounge", venue.Name);
            Assert.AreEqual("Yepford", venue.CityName);
            Assert.AreEqual("Luxury, Modern", venue.Category);
            Assert.AreEqual("IA", venue.StateAbbreviation);

        }
        [TestMethod]
        [DataRow("10")]

        public void GetVenueDetails10(string userinput)
        {
            Venue venue = venueDAO.GetVenueDetails(userinput);

            Assert.AreEqual(14, venue.VenueId);
            Assert.AreEqual("Runaway Time Emporium", venue.Name);
            Assert.AreEqual("Andoshire", venue.CityName);
            Assert.AreEqual("Modern", venue.Category);
            Assert.AreEqual("PA", venue.StateAbbreviation);

        }

        [TestMethod]
        [DataRow(1)]

        public void GetVenueSpaceListTest1(int venueId)
        {
            List<Space> spaces = venueDAO.GetVenueSpaceList(venueId);

            Assert.AreEqual(7, spaces.Count);
            Assert.AreEqual("    ", spaces[0].OpenFromAbb);
            Assert.AreEqual("    ", spaces[0].OpenToAbb);
            Assert.AreEqual(210, spaces[0].MaxOccupancy);
            Assert.AreEqual(5250.00M, spaces[0].DailyRate);
        }

        [TestMethod]
        [DataRow(4)]

        public void GetVenueSpaceListTest4(int venueId)
        {
            List<Space> spaces = venueDAO.GetVenueSpaceList(venueId);

            Assert.AreEqual(3, spaces.Count);
            Assert.AreEqual("Mar", spaces[0].OpenFromAbb);
            Assert.AreEqual("Nov", spaces[0].OpenToAbb);
            Assert.AreEqual(90, spaces[0].MaxOccupancy);
            Assert.AreEqual(900.00M, spaces[0].DailyRate);
        }

        [TestMethod]
        [DataRow(8)]

        public void GetVenueSpaceListTest8(int venueId)
        {
            List<Space> spaces = venueDAO.GetVenueSpaceList(venueId);

            Assert.AreEqual(6, spaces.Count);
            Assert.AreEqual("Aug", spaces[3].OpenFromAbb);
            Assert.AreEqual("Oct", spaces[3].OpenToAbb);
            Assert.AreEqual(200, spaces[3].MaxOccupancy);
            Assert.AreEqual(5000.00M, spaces[3].DailyRate);
        }

        [TestMethod]
        [DataRow(1, "06/16/2021", 1, 100)]

        public void AvailableSpacesTest2Result(int venueId, string date, int days, int attendees)
        {
            List<Space> spaces = venueDAO.GetAvailableSpaces(venueId, date, days, attendees);
            Assert.AreEqual(2, spaces.Count);
            Assert.AreEqual("Saint James Place", spaces[0].Name);
            Assert.AreEqual(4200.00M, spaces[0].TotalCost);
            Assert.AreEqual(210, spaces[0].MaxOccupancy);
        }

        [TestMethod]
        [DataRow(10, "07/06/2021", 3, 5)]

        public void AvailableSpacesTest3Result(int venueId, string date, int days, int attendees)
        {
            List<Space> spaces = venueDAO.GetAvailableSpaces(venueId, date, days, attendees);
            Assert.AreEqual(3, spaces.Count);
            Assert.AreEqual("Purple Porthouse", spaces[1].Name);
            Assert.AreEqual(7800.00M, spaces[0].TotalCost);
            Assert.AreEqual(20, spaces[2].MaxOccupancy);
        }

        [TestMethod]
        [DataRow(1, "07/06/2022", 10, 80)]

        public void AvailableSpacesTestManyResult(int venueId, string date, int days, int attendees)
        {
            List<Space> spaces = venueDAO.GetAvailableSpaces(1, "07/06/2022", 10, 80);
            Assert.AreEqual(4, spaces.Count);
            Assert.AreEqual("Saint James Place", spaces[1].Name);
            Assert.AreEqual(16500.00M, spaces[3].TotalCost);
            Assert.AreEqual(210, spaces[0].MaxOccupancy);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(7)]
        [DataRow(8)]
        [DataRow(4)]
        [DataRow(12)]
        public void AddReservation(int venueId)
        {
            List<Space> spaces = venueDAO.GetVenueSpaceList(venueId);
            Space space = spaces[0];
            int test = venueDAO.AddReservation(space, "06/12/2022", 2, 10, "test");
            Assert.IsNotNull(test);

        }
        [TestMethod]
        [DataRow(10)]

        public void GetReservationConfirmation10(int confirmationNumber)
        {
            Reservation reservation = new Reservation();
            reservation = venueDAO.GetReservationConfirmation(confirmationNumber);
            Assert.AreEqual("Jobs Family Reservation", reservation.ReservedFor);
            Assert.AreEqual(110, reservation.NumberOfAttendees);
            Assert.AreEqual("Rusty Farmer Spot", reservation.VenueName);
            Assert.AreEqual("Summertime Sitting Room", reservation.SpaceName);
            Assert.AreEqual(11400.00M, reservation.TotalCost);
            Assert.AreEqual(confirmationNumber, reservation.ReservationId);
        }
        [TestMethod]
        [DataRow(16)]

        public void GetReservationConfirmation16(int confirmationNumber)
        {
            Reservation reservation = new Reservation();
            reservation = venueDAO.GetReservationConfirmation(confirmationNumber);
            Assert.AreEqual("Schiller Family Reservation", reservation.ReservedFor);
            Assert.AreEqual(35, reservation.NumberOfAttendees);
            Assert.AreEqual("Smirking Stone Bistro", reservation.VenueName);
            Assert.AreEqual("Hidden Sanctuary", reservation.SpaceName);
            Assert.AreEqual(3750.00M, reservation.TotalCost);
            Assert.AreEqual(confirmationNumber, reservation.ReservationId);
        }


        //get venue list -- done
        //get venue details -- done
        //get venue categories -- done in getVenueDetails
        //get venue space list -- done
        //get available spaces -- done
        //add reservation -- done
        //get reservation number -- done in addreservation 
        //get reservation confirmation -- done
    }
}


