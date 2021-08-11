using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;

namespace Capstone.DAL
{
    public class VenueDAO
    {
        // NOTE: No Console.ReadLine or Console.WriteLine in this class
        //string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(8);

        private string connectionString;
        private string sqlGetVenue = "SELECT * FROM venue ORDER BY venue.name;";
        private string sqlGetDetail = "SELECT venue.id 'venue_id', venue.name 'venue_name', city.name 'city_name', " +
            "state.abbreviation, venue.description " +
            "FROM venue JOIN city ON venue.city_id = city.id" +
            " JOIN state ON city.state_abbreviation = state.abbreviation WHERE venue.id = @id;";
        private string sqlGetCategory = " SELECT category.name FROM category JOIN category_venue ON category.id = category_venue.category_id " +
            " JOIN venue ON category_venue.venue_id = venue.id WHERE venue.id = @id;";
        private string sqlGetVenueSpace = " SELECT * FROM space WHERE venue_id = @id;";
        private string sqlAvailableSpaces = "SELECT DISTINCT TOP 5 space.id, space.is_accessible, space.name, space.daily_rate, " +
            "space.max_occupancy, space.venue_id, (space.daily_rate * @days) 'total_cost' " +
            "FROM space " +
            "LEFT JOIN reservation ON space.id = reservation.space_id " +
            "WHERE space.venue_id = @id AND space.id NOT IN  " +
            "( " +
            "SELECT distinct space.id " +
            "FROM  space " +
            "JOIN reservation ON space.id = reservation.space_id " +
            "WHERE space.venue_id = @id AND " +
            "reservation.start_date BETWEEN (CONVERT(DATETIME, @date)) AND(DATEADD(DAY, @days, CONVERT(DATETIME, @date)))  " +
            "OR space.venue_id = @id AND " +
            "reservation.end_date BETWEEN(CONVERT(DATETIME, @date)) AND(DATEADD(DAY, @days, CONVERT(DATETIME, @date))) " +
            ") " +
            "AND @attendees <= space.max_occupancy " +
            "ORDER BY total_cost DESC;";
        private string sqlAddReservation = "INSERT INTO reservation(space_id, number_of_attendees, start_date, end_date, reserved_for) " +
            "VALUES(@spaceId, @attendees, CONVERT(DATETIME, @date), DATEADD(DAY, @days, CONVERT(DATETIME, @date)), @name);";
        private string sqlGetReservationNumber = "SELECT * FROM reservation ORDER BY reservation_id DESC;";
        private string sqlGetReservationDetails = "SELECT reservation.reservation_id, venue.name 'venue_name', space.name 'space_name', " +
            "reservation.reserved_for, reservation.number_of_attendees, reservation.start_date, reservation.end_date, " +
            "(DATEDIFF(day, start_date, end_date)) * space.daily_rate 'total_cost' " +
            "FROM reservation JOIN space ON reservation.space_id = space.id JOIN venue ON space.venue_id = venue.id " +
            "WHERE reservation.reservation_id = @id;";
        public VenueDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Venue> GetVenueList()      // gets list of all venues from database 
        {
            List<Venue> result = new List<Venue>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlGetVenue, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Venue venue = new Venue();
                    venue.VenueId = Convert.ToInt32(reader["id"]);
                    venue.Name = Convert.ToString(reader["name"]);

                    result.Add(venue);
                }
                return result;
            }
        }

        public Venue GetVenueDetails(string userInput)      // gets venue details based on venue selected by user
        {
            List<Venue> venues = GetVenueList();
            int userInputInt = int.Parse(userInput);
            int venueId = venues[userInputInt - 1].VenueId;
            Venue result = new Venue();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlGetDetail, conn);
                cmd.Parameters.AddWithValue("@id", venueId);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.VenueId = venueId;
                    result.Name = Convert.ToString(reader["venue_name"]);
                    result.Description = Convert.ToString(reader["description"]);
                    result.CityName = Convert.ToString(reader["city_name"]);
                    result.StateAbbreviation = Convert.ToString(reader["abbreviation"]);


                }
            }
            result = GetVenueCategory(result, venueId);
            return result;
        }
        private Venue GetVenueCategory(Venue venue, int venueId)     //gets category string for venue selected adds as parameter and returns updated venue only call from GetVenueDetails
        {
            string category = "";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlGetCategory, conn);
                cmd.Parameters.AddWithValue("@id", venueId);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    category += Convert.ToString(reader["name"]) + ", ";
                }
            }
            venue.Category = category.Remove(category.Length - 2);
            return venue;
        }
        public List<Space> GetVenueSpaceList(int venueId)  //gets list of spaces based on venue id converts open/close months to month abbreviations
        {
            List<Space> result = new List<Space>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlGetVenueSpace, conn);
                cmd.Parameters.AddWithValue("@id", venueId);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Space space = new Space();
                    space.SpaceId = Convert.ToInt32(reader["id"]);
                    space.Name = Convert.ToString(reader["name"]);
                    if (!Convert.IsDBNull(reader["open_from"]))
                    {
                        space.OpenFromAbb = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(reader["open_from"]));
                    }
                    else
                    {
                        space.OpenFromAbb = "    ";
                    }
                    if (!Convert.IsDBNull(reader["open_to"]))
                    {
                        space.OpenToAbb = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(reader["open_to"]));
                    }
                    else
                    {
                        space.OpenToAbb = "    ";
                    }
                    space.DailyRate = Convert.ToDecimal(reader["daily_rate"]);
                    space.MaxOccupancy = Convert.ToInt32(reader["max_occupancy"]);
                    result.Add(space);

                }

            }

            return result;
        }

        public List<Space> GetAvailableSpaces(int venueId, string date, int days, int attendees) // gets available spaces based on user input of start date, days needed, and number of attendees returns list of spaces
        {
            List<Space> result = new List<Space>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlAvailableSpaces, conn);
                cmd.Parameters.AddWithValue("@id", venueId);
                cmd.Parameters.AddWithValue("@days", days);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@attendees", attendees);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Space space = new Space();
                    space.SpaceId = Convert.ToInt32(reader["id"]);
                    space.Name = Convert.ToString(reader["name"]);
                    space.DailyRate = Convert.ToDecimal(reader["daily_rate"]);
                    space.MaxOccupancy = Convert.ToInt32(reader["max_occupancy"]);
                    if (Convert.ToBoolean(reader["is_accessible"]))
                    {
                        space.IsAccessible = "Yes";
                    }
                    else
                    {
                        space.IsAccessible = "No";
                    }
                    space.TotalCost = Convert.ToDecimal(reader["total_cost"]);
                    result.Add(space);
                }
            }
            return result;
        }

        public int AddReservation(Space space, string date, int days, int attendees, string name)  //adds reservation and returns new reservation id
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlAddReservation, conn);
                cmd.Parameters.AddWithValue("@spaceId", space.SpaceId);
                cmd.Parameters.AddWithValue("@attendees", attendees);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@days", days);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.ExecuteNonQuery();
            }
            result = GetReservationNumber();

            return result;
        }
        private int GetReservationNumber()      // gets reservation number based on reservation added, only call from AddReservation
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlGetReservationNumber, conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public Reservation GetReservationConfirmation(int confirmationNumber)  // gets reservation details based on confirmation id returns a reservation with details set as properties.
        {
            Reservation result = new Reservation();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlGetReservationDetails, conn);
                cmd.Parameters.AddWithValue("@id", confirmationNumber);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.ReservationId = confirmationNumber;
                    result.VenueName = Convert.ToString(reader["venue_name"]);
                    result.SpaceName = Convert.ToString(reader["space_name"]);
                    result.ReservedFor = Convert.ToString(reader["reserved_for"]);
                    result.NumberOfAttendees = Convert.ToInt32(reader["number_of_attendees"]);
                    result.ReservedFrom = Convert.ToDateTime(reader["start_date"]);
                    result.ReservedTo = Convert.ToDateTime(reader["end_date"]);
                    result.TotalCost = Convert.ToDecimal(reader["total_cost"]);
                }
            }
            return result;
        }




        //todo public List GetVenueList -- done       
        //todo public string GetVenueDetails -- done
        //todo public List GetVenueSpaceList -- done
        //todo public List GetAvailableSpaces -- done
        //todo public int AddReservation -- done
        //todo public string GetReservationConfirmation (AddReservation int) -- done

    }
}
