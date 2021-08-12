using System;
using System.Collections.Generic;
using System.Text;

namespace PetInfo
{
    public class Parrot : Pet
    {
       
        public DateTime Polyomavirus { get; set; }
        public Parrot(int id, string name, string type,
            string breed) : base(id, name, type, breed)
        {
            Console.WriteLine("Created a parrot.");
        }
        public override DateTime NextVetVisit()
        {
            DateTime result = LastVetVisit.AddYears(5);
            return result;
        }

    }
}
