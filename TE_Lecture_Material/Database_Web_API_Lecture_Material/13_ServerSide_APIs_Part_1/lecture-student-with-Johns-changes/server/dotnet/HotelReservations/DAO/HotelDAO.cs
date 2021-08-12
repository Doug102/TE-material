using HotelReservations.Dao;
using HotelReservations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace HotelReservations.DAO
{
    public class HotelDAO : IHotelDao
    {
        private string connectionString = "";

        private string sqlList = "SELECT * FROM hotel";
        private string sqlGet = "SELECT * FROM hotel WHERE id = @id;";

        public HotelDAO()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            string connectionString = configuration.GetConnectionString("HotelReservation");

            this.connectionString = connectionString;
        }

        public List<Hotel> List()
        {
            List<Hotel> result = new List<Hotel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlList, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read() == true)
                    {
                        Hotel hotel = new Hotel();

                        hotel.Id = Convert.ToInt32(reader["id"]);
                        hotel.Name = Convert.ToString(reader["name"]);
                        hotel.Address.StreetAddress = Convert.ToString(reader["streetaddress"]);
                        hotel.Address.StreetAddress2 = Convert.ToString(reader["streetaddress2"]);
                        hotel.Address.City = Convert.ToString(reader["city"]);
                        hotel.Address.State = Convert.ToString(reader["state"]);
                        hotel.Address.Zip = Convert.ToString(reader["zip"]);
                        hotel.Stars = Convert.ToInt32(reader["stars"]);
                        hotel.RoomsAvailable = Convert.ToInt32(reader["roomsavailable"]);
                        hotel.CostPerNight = Convert.ToInt32(reader["costpernight"]);
                        hotel.CoverImage = Convert.ToString(reader["coverimage"]);
           

                        result.Add(hotel);
                    }
                }
            }
            catch (Exception ex)
            {
                result = new List<Hotel>();
            }

            return result;
        }

        public Hotel Get(int id)
        {
            Hotel hotel = new Hotel();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGet, conn);
                    cmd.Parameters.AddWithValue("id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read() == true)
                    {

                        hotel.Id = Convert.ToInt32(reader["id"]);
                        hotel.Name = Convert.ToString(reader["name"]);
                        hotel.Address.StreetAddress = Convert.ToString(reader["streetaddress"]);
                        hotel.Address.StreetAddress2 = Convert.ToString(reader["streetaddress2"]);
                        hotel.Address.City = Convert.ToString(reader["city"]);
                        hotel.Address.State = Convert.ToString(reader["state"]);
                        hotel.Address.Zip = Convert.ToString(reader["zip"]);
                        hotel.Stars = Convert.ToInt32(reader["stars"]);
                        hotel.RoomsAvailable = Convert.ToInt32(reader["roomsavailable"]);
                        hotel.CostPerNight = Convert.ToInt32(reader["costpernight"]);
                        hotel.CoverImage = Convert.ToString(reader["coverimage"]);
                    }
                }
            }
            catch (Exception ex)
            {
                hotel = new Hotel();
            }

            return hotel;
        }
    }
}


