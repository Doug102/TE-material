using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservations.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        //GET: /
        [HttpGet]
        public string Ready()
        {
            return "Server is Ready.";
        }
    }
}
