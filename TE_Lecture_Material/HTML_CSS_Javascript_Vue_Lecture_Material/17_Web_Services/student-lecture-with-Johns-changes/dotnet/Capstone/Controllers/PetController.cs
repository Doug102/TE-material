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
    //[Authorize]
    [Route("[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private IPetDAO petDAO;

        public PetController(IPetDAO petDAO)
        {
            this.petDAO = petDAO;
        }

        [HttpGet]
        public ActionResult<List<Pet>> GetPets()
        {
            return petDAO.GetPets();
        }

        [HttpGet("petId")]
        public ActionResult<Pet> GetPet(int petId)
        {
            return Ok(petDAO.GetPet(petId));
        }

        [HttpPost]
        public ActionResult AddPet(Pet pet)
        {

            return BadRequest();
            //bool result = petDAO.AddPet(pet);

            //if (result)
            //{
            //    return Ok();
            //}
            //else
            //{
            //    return BadRequest();
            //}
        }
    }
}
