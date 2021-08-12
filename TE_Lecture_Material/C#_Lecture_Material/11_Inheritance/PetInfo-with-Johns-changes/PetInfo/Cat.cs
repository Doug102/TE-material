using System;
using System.Collections.Generic;
using System.Text;

namespace PetInfo
{
    public class Cat : Pet
    {

        public DateTime DateOfFelineDistemper { get; set; }
        public DateTime DateOfFelineHerpesvirusTypeI { get; set; }
        public DateTime DateOfRabies { get; set; }
        public DateTime DateOfFelineLeukemiaVirus { get; set; }
        public DateTime DateOfBordetella { get; set; }
        public DateTime DateOfFelineImmunodeficiencyVirus { get; set; }
       
        public Cat(int id, string name, string type,
            string breed) : base(id, name, type,breed)
        {
            Console.WriteLine("Created a cat.");
        }
    }
}