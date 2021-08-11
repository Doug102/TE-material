using System;

namespace Precision_example
{
    class Program
    {
        static void Main(string[] args)
        {
            float a = 1.03f;
            float b = 0.42f;
            double c = a - b;
            Console.WriteLine("1.03 - 0.42 with mixed float and double (A) = " + c);

            double d = 1.03f;
            double e = 0.42f;
            double f = d - e ;
            Console.WriteLine("1.03 - 0.42 with mixed float and double (B) = " + f);

            double g = 1.03;
            double h = 0.42;
            double i = g - h;
            Console.WriteLine("1.03 - 0.42 with all double = " + i);

            float j = 1.03f;
            float k = 0.42f;
            float l = j - k;
            Console.WriteLine("1.03 - 0.42 with all float = " + l);

            Console.ReadLine();
        }
    }
}
