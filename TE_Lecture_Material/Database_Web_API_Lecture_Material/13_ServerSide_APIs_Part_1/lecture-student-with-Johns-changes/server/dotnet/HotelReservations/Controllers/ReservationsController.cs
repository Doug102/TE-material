using HotelReservations.Dao;
using HotelReservations.DAO;
using HotelReservations.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservations.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private IReservationDao _reservationDao;

        public ReservationsController()
        {
            _reservationDao = new ReservationDAO();
        }

        //GET: /reservations
        [HttpGet]
        public List<Reservation> ListReservations()
        {
            return _reservationDao.List();
        }


        //GET: /reservations/4
        [HttpGet("{id}")]
        public Reservation GetReservation(int id)
        {
            return _reservationDao.Get(id);
        }


        //POST /reservations


    }


}
