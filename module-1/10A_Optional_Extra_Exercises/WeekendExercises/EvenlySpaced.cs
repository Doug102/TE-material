using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class Exercises
    {
        /*
        Given three ints, a b c, one of them is small, one is medium and one 
        is large. Return true if the three values are evenly 
        spaced, so the difference between small and medium is the same as 
        the difference between medium and large.
        evenlySpaced(2, 4, 6) → true
        evenlySpaced(4, 6, 2) → true
        evenlySpaced(4, 6, 3) → false
        */
        public bool EvenlySpaced(int a, int b, int c)
        {
            int large = 0;
            int medium = 0;
            int small = 0;

            if (a > b && a > c)
            {
                large = a;
            }
            if ((a > b && a < c) || (a > c && a < b))
            {
                medium = a;
            }
            if (a < b && a < c)
            {
                small = a;
            }
            if (b > a && b > c)
            {
                large = b;
            }
            if ((b > a && b < c) || (b > c && b < a))
            {
                medium = b;
            }
            if (b < a && b < c)
            {
                small = b;
            }
            if (c > b && c > a)
            {
                large = c;
            }
            if ((c > b && c < a) || (c > a && c < b))
            {
                medium = c;
            }
            if (c < b && c < a)
            {
                small = c;
            }

            if ((large - medium) == (medium - small))
            {
                return true;
            }
            return false;

        }
    }
}

// Stuck? - Here is a solution - https://vimeo.com/501475854/6070eb33f5
