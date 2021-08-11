using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetInfoClient.Models;
using PetInfoServer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetInfoServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private IPetDAO petDAO;

        public PetController(IPetDAO petDAO)
        {
            this.petDAO = petDAO;
        }


        //GET: /pet
        [HttpGet]
        public ActionResult<List<Pet>> getPets()
        {

            List<Pet> pets = petDAO.GetPets();

            if (pets.Count > 0)
            {
                return Ok(pets);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<bool> AddAPet(Pet pet)
        {
            bool result = petDAO.AddPet(pet);
           if (result)
            {
                return Ok(result);
            }
           else
            {
                return NotFound(result);
            }


        }
    }
}
