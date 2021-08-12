using System;

namespace Capstone.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
         public string Type { get; set; }
        public virtual string Breed { get; set; }
        public DateTime Birthdate { get; set; }
        public bool IsSpayedOrNeutered { get; set; }
        public DateTime LastVetVisit { get; set; }
        public string Image { get; set; }
        public int Age { get; set; }

        public Pet(string name)
        {
            Name = name;
        }
        public Pet()
        {

        }

        public override string ToString()
        {
            return $"{Id} - {Name} - {Type} - {Breed}";
        }
    }
}


