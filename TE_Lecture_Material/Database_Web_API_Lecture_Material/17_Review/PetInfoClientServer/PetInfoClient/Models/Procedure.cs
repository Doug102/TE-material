using System;
using System.Collections.Generic;
using System.Text;

namespace PetInfoClient.Models
{
     public class Procedure
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Id + " - " + Name;
        }
    }
}
