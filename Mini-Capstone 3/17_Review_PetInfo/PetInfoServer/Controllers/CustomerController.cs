using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetInfoServer.DAL.Interfaces;
using PetInfoServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetInfoServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerDAO customerDAO;
        public CustomerController(ICustomerDAO customerDAO)
        {
            this.customerDAO = customerDAO;
        }

        [HttpGet]
        public ActionResult<List<Customer>> GetCustomers()
        {
            return Ok(customerDAO.GetCustomers());
            //List < Customer > = customerDAO.GetCustomers();
        }
    }
}
