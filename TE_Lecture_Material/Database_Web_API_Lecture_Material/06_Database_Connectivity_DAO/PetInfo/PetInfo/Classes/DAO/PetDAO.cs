using System;
using System.Collections.Generic;
using System.Text;

namespace PetInfo.Classes.DAO
{
    class PetDAO
    {

        private string connectionString = "connection string goes here";
        public List<Pet> GetPets()
        {
            List<Pet> pets = new List<Pet>();
            return pets;

        }


        public bool SetPets(Dictionary<int, Pet> pets)
        {
            return true;
        }
    }
}
