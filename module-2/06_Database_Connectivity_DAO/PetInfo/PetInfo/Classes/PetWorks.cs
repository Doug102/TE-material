using PetInfo.Classes.DAO;
using System.Collections.Generic;

namespace PetInfo
{
    public class PetWorks
    {
        private PetDAO petDAO = new PetDAO();

        public bool AddPet( int id, string name, string type, string breed)
        {
            Dictionary<int, Pet> pets = new Dictionary<int, Pet>();
            bool result = false;

            // read the file
            Pet[] petArray = GetPets();

            //create a dictionary
            foreach (Pet tempPet in petArray)
            {
                pets[tempPet.Id] = tempPet;
            }


            Pet pet = new Pet(id, name, type, breed);

            // updated the new pet
            if (!pets.ContainsKey(id))
            {
                 pets.Add(id, pet);
                result = true;
            }

            // write the file
            result =  result && petDAO.SetPets(pets);

            return result;
        }


        public Pet[] GetPets()
        {
            Pet[] result = petDAO.GetPets().ToArray();
            return result;
        }

        public bool DeletePet(int id)
        {
            Dictionary<int, Pet> pets = new Dictionary<int, Pet>();
            bool result = false;

            // read the file
            Pet[] petArray = GetPets();

            //create a dictionary
            foreach (Pet tempPet in petArray)
            {
                pets[tempPet.Id] = tempPet;
            }

            // does pet exist
            if (pets.ContainsKey(id))
            {
                pets.Remove(id);
                result = true;
            }

            // write the file
            result = result && petDAO.SetPets(pets);

            return result;
        }
    }
}
