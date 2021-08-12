using System;
using System.Collections.Generic;
using System.Text;

namespace PetInfo
{
    public class Pet
    {
        private string name;

        public int Id { get; set; }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Type { get; set; }
        public string Breed { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime SpayedOrNeutered { get; set; }
        public DateTime LastVetVisit { get; set; }


        public Pet(int id, string name, string type,
            string breed)
        {
            Id = id;
            Name = name;
            Type = type;
            Breed = breed;

            LastVetVisit = DateTime.Now;

            Console.WriteLine("Created a pet.");
        }

        public override string ToString()
        {
            return Name + " - " + Type + " - " + Breed;
        }

        public virtual  DateTime NextVetVisit()
        {
            DateTime result = LastVetVisit.AddYears(1);
            return result;
        }
    }
}
