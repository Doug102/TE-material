using Lecture.Farming;
using System;

namespace Lecture
{
    class Program
    {
        static void Main()
        {
            //
            // OLD MACDONALD
            //

            ISingable[] singables = new ISingable[]
            {
                new Cow(), new Chicken(), new Pig(), new Tractor(), new Cat()
            };

            foreach(ISingable singable in singables)
            {
                Console.WriteLine("Old MacDonald had a farm, ee ay ee ay oh!");
                Console.WriteLine("And on his farm he had a " + singable.Name + ", ee ay ee ay oh!");
                Console.WriteLine("With a " + singable.Sound + " " + singable.Sound + " here");
                Console.WriteLine("And a " + singable.Sound + " " + singable.Sound + " there");
                Console.WriteLine("Here a " + singable.Sound + " there a " + singable.Sound + " everywhere a " + singable.Sound + " " + singable.Sound);
                Console.WriteLine();
            }

            Console.WriteLine("Old MacDonald had a farm, ee ay ee ay oh!");
            Console.WriteLine();
            Console.WriteLine();

            ISellable[] sellables = new ISellable[]
            {
                new Cow(), new Pig(), new Egg(), new Cat()
            };

            foreach(ISellable sellable in sellables)
            {
                Console.WriteLine("Step right up and get your " + sellable.Name);
                Console.WriteLine("Only $" + sellable.Price);
            }
        }
    }
}