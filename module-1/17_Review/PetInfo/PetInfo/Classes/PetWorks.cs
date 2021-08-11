using System.Collections.Generic;

namespace PetInfo
{
    public class PetWorks
    {
        private DataAccess data = new DataAccess();

        // This (pets as a Dictionary stored here) is no longer a good idea.
        // If AddPet and DeletePet can change the data, we are updating two places (here and the disk file).
        // That's never a good idea unless there's a REALLY good reason.

        //private Dictionary<int, Pet> pets = new Dictionary<int, Pet>();

        //public PetWorks()
        //{
        //    Pet[] petList = data.GetPets();

        //    foreach(Pet pet in petList)
        //    {
        //        pets[pet.Id] = pet;
        //    }

        //}





        public Pet[] GetPets()
        {

            //Pet[] result = new Pet[pets.Count];

            //int i = 0;
            //foreach(Pet pet in pets.Values)
            //{
            //    result[i] = pet;
            //    i++;
            //}
            Pet[] result = data.GetPets();

            return result;
        }

        public bool AddPet(int id, string name, string type, string breed)

        //todo addpet
        {
            Dictionary<int, Pet> pets = new Dictionary<int, Pet>();
            bool result = false;
            Pet[] petArray = GetPets();
            foreach (Pet tempPet in petArray)
            {
                pets[tempPet.Id] = tempPet;
            }
            Pet pet = new Pet(id, name, type, breed);

            if (!pets.ContainsKey(id))
            {
                pets.Add(id, pet);
                result = true;
            }
            result = result && data.SetPets(pets);
            return result;
            

            //bool result = false;
            //Pet pet = new Pet(id, name, type, breed);

            //if (!pets.ContainsKey(id))
            //{
            //    pets.Add(id, pet);
            //    result = true;
            //}

            ////update file on disk

            //return result;
            
        }

        public bool DeletePet(int id)
        {
            
                Dictionary<int, Pet> pets = new Dictionary<int, Pet>();
                bool result = false;
                Pet[] petArray = GetPets();
                foreach (Pet tempPet in petArray)
                {
                    pets[tempPet.Id] = tempPet;
                }
               

                if (pets.ContainsKey(id))
                {
                    pets.Remove(id);
                    result = true;
                }
                result = result && data.SetPets(pets);
                return result;
                //todo deletepet
                //bool result = false;

                //if (pets.ContainsKey(id))
                //{
                //    pets.Remove(id);
                //    result = true;
                //}

                //// update file on disk

                //return result;
                //return false;
        }
    }
}
