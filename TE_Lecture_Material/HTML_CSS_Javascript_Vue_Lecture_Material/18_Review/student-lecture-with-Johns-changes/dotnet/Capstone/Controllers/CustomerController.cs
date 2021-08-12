using Capstone.DAO.Interfaces;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerDAO customerDAO;

        public CustomerController(ICustomerDAO petDAO)
        {
            this.customerDAO = petDAO;
        }

        [HttpGet]
        public ActionResult<List<Customer>> GetPets()
        {
            return Ok(customerDAO.GetCustomers());
        }

        [HttpGet("petId")]
        public ActionResult<Customer> GetPet(int petId)
        {
            return Ok(customerDAO.GetCustomer(petId));
        }

        [HttpPost]
        public ActionResult AddPet(Customer pet)
        {
            bool result = customerDAO.AddCustomer(pet);

            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
