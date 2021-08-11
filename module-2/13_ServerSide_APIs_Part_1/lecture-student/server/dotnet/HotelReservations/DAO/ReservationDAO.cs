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
    public class ReservationDAO : IReservationDao
    {
        private string connectionString = "";

        private string sqlList = "SELECT * FROM reservation";
        private string sqlGet = "SELECT * FROM reservation WHERE id = @id;";
        private string sqlFindByHotel = "SELECT * FROM reservation WHERE hotelid = @hotelid;";

        public ReservationDAO()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            string connectionString = configuration.GetConnectionString("HotelReservation");

            this.connectionString = connectionString;
        }

        public List<Reservation> List()
        {
            List<Reservation> result = new List<Reservation>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlList, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read() == true)
                    {
                        Reservation reservation = new Reservation();

                        reservation.Id = Convert.ToInt32(reader["id"]);
                        reservation.HotelId = Convert.ToInt32(reader["hotelid"]);
                        reservation.FullName = Convert.ToString(reader["fullname"]);
                        reservation.CheckinDate = Convert.ToString(reader["checkindate"]);
                        reservation.CheckoutDate = Convert.ToString(reader["checkoutdate"]);
                        reservation.Guests = Convert.ToInt32(reader["guests"]);

                        result.Add(reservation);
                    }
                }
            }
            catch (Exception ex)
            {
                result = new List<Reservation>();
            }

            return result;
        }

        public Reservation Get(int id)
        {
            Reservation reservation = new Reservation();

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

                        reservation.Id = Convert.ToInt32(reader["id"]);
                        reservation.HotelId = Convert.ToInt32(reader["hotelid"]);
                        reservation.FullName = Convert.ToString(reader["fullname"]);
                        reservation.CheckinDate = Convert.ToString(reader["checkindate"]);
                        reservation.CheckoutDate = Convert.ToString(reader["checkoutdate"]);
                        reservation.Guests = Convert.ToInt32(reader["guests"]);
                    }
                }
            }
            catch (Exception ex)
            {
                reservation = new Reservation();
            }

            return reservation;
        }

        public List<Reservation> FindByHotel(int hotelId)
        {
            List<Reservation> result = new List<Reservation>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlFindByHotel, conn);
                    cmd.Parameters.AddWithValue("hotelid", hotelId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read() == true)
                    {
                        Reservation reservation = new Reservation();

                        reservation.Id = Convert.ToInt32(reader["id"]);
                        reservation.HotelId = Convert.ToInt32(reader["hotelid"]);
                        reservation.FullName = Convert.ToString(reader["fullname"]);
                        reservation.CheckinDate = Convert.ToString(reader["checkindate"]);
                        reservation.CheckoutDate = Convert.ToString(reader["checkoutdate"]);
                        reservation.Guests = Convert.ToInt32(reader["guests"]);

                        result.Add(reservation);
                    }
                }
            }
            catch (Exception ex)
            {
                result = new List<Reservation>();
            }

            return result;
        }

        public Reservation Create(Reservation reservation)
        {
            return new Reservation();
        }

    }
}
