using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HotelReservations.Models;
using HotelReservations.Dao;

namespace HotelReservations.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private static IHotelDao hotelDao;
        private static IReservationDao reservationDao;

        public ReservationsController(IHotelDao _hotelDao, IReservationDao _reservationDao)
        {
            hotelDao = _hotelDao;
            reservationDao = _reservationDao;
        }

        //GET: /reservations
        [HttpGet]
        public ActionResult<List<Reservation>> ListReservations()
        {
            int zero = 0;
            int result = 7 / zero;
            return Ok(reservationDao.List());
        }

        //GET: /reservations/4
        [HttpGet("{id}")]
        public ActionResult<Reservation> GetReservation(int id)
        {
            Reservation reservation = reservationDao.Get(id);

            if (reservation != null)
            {
                return Ok(reservation);
            }
            else
            {
                return NotFound();
            }
        }

        //POST: /reservations
        [HttpPost]
        public ActionResult<Reservation> AddReservation(Reservation reservation)
        {
            Reservation added = reservationDao.Create(reservation);
            return Created($"/reservations/{added.Id}", added);
        }

        //PUT: /reservations/5
        [HttpPut("{id}")]
        public ActionResult<Reservation> ChangeReservation(int id, Reservation reservation)
        {
            Reservation added = reservationDao.Update(id, reservation);
            if (added != null)
            {
                return Ok(added);
            }
            else
            {
                return NotFound();
            }
         
        }

        //DELETE: /reservations/4
        [HttpDelete("{id}")]
        public ActionResult DeleteReservations(int id)
        {
            if (reservationDao.Delete(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
           
        }
    }
}
