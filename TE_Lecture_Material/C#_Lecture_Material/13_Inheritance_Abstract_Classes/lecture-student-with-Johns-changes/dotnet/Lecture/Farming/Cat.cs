using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    class Cat : FarmAnimal, ISellable
    {
        sealed public override string Name { get; } = "Cat";
        public decimal Price { get; } = 5;

        public Cat() : base("Meow")
        {

        }
    }
}
