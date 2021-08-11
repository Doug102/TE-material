using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO.Interfaces
{
    public interface IPetDAO
    {
        List<Pet> GetPets();
        Pet GetPet(int petId);
        bool AddPet(Pet pet);
       
    }
}
