using System.Collections.Generic;

namespace PetInfo
{
    public class PetWorks
    {

        private Dictionary<int, Pet> pets = new Dictionary<int, Pet>();



        public bool AddPet( int id, string name, string type, string breed)
        {
            bool result = false;
            Pet pet = new Pet(id, name, type, breed);

            if (!pets.ContainsKey(id))
            {
                pets.Add(id, pet);
                result = true;
            }

            return result;
        }


        public Pet[] GetPets()
        {
            Pet[] result = new Pet[pets.Count];

            int i = 0;
            foreach(Pet pet in pets.Values)
            {
                result[i] = pet;
                i++;
            }

            return result;
        }

        public bool DeletePet(int id)
        {
            bool result = false;

            if (pets.ContainsKey(id))
            {
                pets.Remove(id);
                result = true;
            }

            return result;
        }
    }
}
