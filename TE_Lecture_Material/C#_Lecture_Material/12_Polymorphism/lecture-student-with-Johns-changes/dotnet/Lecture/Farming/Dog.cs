using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Dog : FarmAnimal, IMakeSound
    {
        public override int GetAge()
        {
            return 3;
        }

        public Dog() : base("Dog", "woof")
        {

        }
    }
}
