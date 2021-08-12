using Microsoft.AspNetCore.Mvc;
using PetInfoClient.Models;
using PetInfoServer.DAL.Interfaces;
using System.Collections.Generic;

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
        public ActionResult<List<Pet>> GetPets()
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

        //POST: /pet
        [HttpPost]
        public ActionResult<bool> AddPet(Pet pet)
        {
            bool result = petDAO.AddPet(pet);

            if(result)
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
