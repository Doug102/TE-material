using System;
using System.Collections.Generic;
using System.Text;

namespace PetInfoClient.Models
{
    public class Pet
    {
        private string name;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Breed { get; set; }
        public int Owner { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Name} - {Type} - {Breed}";
        }
    }
}


