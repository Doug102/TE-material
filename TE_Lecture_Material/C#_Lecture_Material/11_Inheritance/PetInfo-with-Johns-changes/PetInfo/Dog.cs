using System;
using System.Collections.Generic;
using System.Text;

namespace PetInfo
{
    public class Dog : Pet
    {
        public DateTime DateOfCanineParvovirus { get; set; }
        public DateTime DateOfDistemper { get; set; }
        public DateTime DateOfCanineHepatitis { get; set; }
        public DateTime DateOfRabies { get; set; }
        public DateTime DateOfBordetella { get; set; }
        public DateTime DateOfLeptospira { get; set; }

        public Dog(int id, string name, string type,
            string breed) : base(id, name,type, breed)
        {
            Console.WriteLine("Created a dog.");
        }
    }
}