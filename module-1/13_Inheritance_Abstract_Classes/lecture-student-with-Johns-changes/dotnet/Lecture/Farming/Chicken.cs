using System;

namespace Lecture.Farming
{
    public class Chicken : FarmAnimal
    {
        public override string Name {get;}
        public Chicken() : base("cluck")
        {
            Name = "Chicken";
        }

        public void LayEgg()
        {
            Console.WriteLine("Chicken laid an egg!");
        }
    }
}
