using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HotelReservations.Models;
using HotelReservations.Dao;
using HotelReservations.DAO;

namespace HotelReservations.Controllers
{
    [Route("[controller]")]

    [ApiController]
    public class HotelsController : ControllerBase
    {
        private static IHotelDao _hotelDao;
        private static IReservationDao _reservationDao;

        public HotelsController()
        {
            _hotelDao = new HotelDAO();
            _reservationDao = new ReservationDAO();
        }

        //GET: /
        //[HttpGet]
        //public string Ready()
        //{
        //    return "Server is ready!";
        //}

        //GET: /hotels
        [HttpGet]
        public List<Hotel> ListHotels()
        {
            return _hotelDao.List();
        }

        //GET: /hotels/5
        [HttpGet("{id}")]
        public Hotel GetHotel(int id)
        {
            Hotel hotel = _hotelDao.Get(id);

            if (hotel != null)
            {
                return hotel;
            }

            return null;
        }




        //GET: /hotels/4/reservations
        [HttpGet("{id}/reservations")] 
        public List<Reservation> GetReservationsByHotelId(int id)
        {
            List<Reservation> reservations = _reservationDao.FindByHotel(id);
            return reservations;
        }

      
        //GET: /hotels/filter?state=OH&city=Cleveland
        [HttpGet("filter")]
        public List<Hotel> GetHotelsByParameter(string state, string city)
        {
            return null;
        }


    }
}
