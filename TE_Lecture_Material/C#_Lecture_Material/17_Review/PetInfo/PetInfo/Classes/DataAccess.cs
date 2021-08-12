using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PetInfo
{
    class DataAccess
    {
        private string filename = @"C:\PetInfo\data.csv";

        public Pet[] GetPets()
        {
            List<Pet> pets = new List<Pet>();

            using (StreamReader sr = new StreamReader(filename))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] split = line.Split(',');

                    Pet pet = new Pet();
                    pet.Id = int.Parse(split[0]);
                    pet.Name = split[1];
                    pet.Type = split[2];
                    pet.Breed = split[3];

                    pets.Add(pet);
                }
            }

            return pets.ToArray();
        }

        public bool SetPets(Pet[] pets) 
        {
            return false;
        }
        public bool SetPets(Dictionary<int, Pet> pets)
        {
            using(StreamWriter sw = new StreamWriter(filename, false))
            {
                foreach (Pet pet in pets.Values)
                {
                    sw.WriteLine($"{pet.Id},{pet.Name},{pet.Type},{pet.Breed}");
                }
            }
            return true;
        }

    }
}

