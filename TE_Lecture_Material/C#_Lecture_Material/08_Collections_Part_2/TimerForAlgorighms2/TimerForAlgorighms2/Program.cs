using System;
using System.Diagnostics;

namespace TimerForAlgorighms2
{
    class Program
    {
        static void Main(string[] args)
        {
            int howManyTimes = 1;
            string whichToRun = "";
            bool done = false;

            while (!done)
            {
                Console.Write("How many times to run loop? (5,000 is a good start, 0 to stop) ");
                howManyTimes = int.Parse(Console.ReadLine());

                if (howManyTimes == 0)
                {
                    done = true;
                    continue;
                }

                Console.Write("L for Linear, S for Square, B for Both ");
                whichToRun = Console.ReadLine();
                whichToRun = whichToRun.ToUpper();

                if (whichToRun == "L" || whichToRun == "B")
                {
                    Stopwatch watch1 = Stopwatch.StartNew();

                    // the code that you want to measure goes here

                    Console.WriteLine("For " + howManyTimes + " times throught the loop:");

                    for (int i = 0; i < howManyTimes; i++)
                    {
                        //do some work - it doesn't really matter what
                        TheWork();
                    }

                    //end of the code to be measured

                    watch1.Stop();
                    long elapsedMs = watch1.ElapsedMilliseconds;
                    Console.WriteLine("Linear time: about " + elapsedMs + " milliseconds");
                }

                if (whichToRun == "S" || whichToRun == "B")
                {

                    System.Diagnostics.Stopwatch watch2 = System.Diagnostics.Stopwatch.StartNew();

                    // the code that you want to measure goes here

                    for (int i = 0; i < howManyTimes; i++)
                    {
                        for (int j = 0; j < howManyTimes; j++)
                        {
                            //do some work - it doesn't really matter what
                            TheWork();
                        }
                    }

                    //end of the code to be measured

                    watch2.Stop();
                    long elapsedMs = watch2.ElapsedMilliseconds;
                    Console.WriteLine("Squared time: about " + elapsedMs + " milliseconds");
                }

                Console.WriteLine();
                Console.WriteLine();

            }
        }

        static void TheWork()
        {
            int[] someArray = new int[100];
        }
    }
}
