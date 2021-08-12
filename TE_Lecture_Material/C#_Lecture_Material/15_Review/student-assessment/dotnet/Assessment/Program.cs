using System;

namespace Assessment.Models

{
   public class Program
    {
        static void Main(string[] args)
        {
            // create an object and call methods on it
            // (manual testing) from this class.
            FlowerShopOrder test = new FlowerShopOrder("standard bouquet", 5);
            Console.WriteLine("Manual property tests");
            Console.WriteLine();
            Console.WriteLine(test.NumberOfRoses);
            Console.WriteLine(test.BouquetType);
            Console.WriteLine(test.Subtotal);
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Manual delivery total tests");
            Console.WriteLine();
            Console.WriteLine(test.DeliveryTotal(true, "20152"));
            Console.WriteLine(test.DeliveryTotal(false, "20152"));
            Console.WriteLine(test.DeliveryTotal(true, "30158"));
            Console.WriteLine(test.DeliveryTotal(false, "30158"));
            Console.WriteLine(test.DeliveryTotal(true, "10167"));
            Console.WriteLine(test.DeliveryTotal(false, "10167"));
            Console.WriteLine(test.DeliveryTotal(true, "529"));
            Console.WriteLine(test.DeliveryTotal(false, "529"));
            Console.WriteLine(test.DeliveryTotal(true, "40596"));
            Console.WriteLine(test.DeliveryTotal(false, "40596"));
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Manual ToString override test");
            Console.WriteLine();
            Console.WriteLine(test.ToString());


        }
    }
}
