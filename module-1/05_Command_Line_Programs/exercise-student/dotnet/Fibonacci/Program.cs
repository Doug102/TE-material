using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a number: ");
            string stopString = Console.ReadLine();

            int stopInt = int.Parse(stopString);

            int[] fibSeq = new int[100];

            for (int i = 0; i < fibSeq.Length; i++)
            {
                if (i == 0)
                {
                    fibSeq[i] = 0;
                }
                else if (i == 1)
                {
                    fibSeq[i] = 1;
                }
                else
                {
                    fibSeq[i] = fibSeq[i - 1] + fibSeq[i - 2];
                }
                    
            }
            string fibSeqString = "";
            for (int i = 0; i < fibSeq.Length; i++)
            {
                if (fibSeq[i] <= stopInt && fibSeq[i] >= 0)
                {
                    fibSeqString += fibSeq[i] + ", ";
                }
            }

            Console.WriteLine(fibSeqString);


        }
    }
}
