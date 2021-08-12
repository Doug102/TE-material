using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
     public class  Cat : FarmAnimal, ISellable
    {
        sealed public override string Name { get; }
        public decimal Price { get; } = 5;
        public Cat() : base("Meow")
        {
            Name = "Cat";
        }

    }
}
