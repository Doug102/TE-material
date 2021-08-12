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
         You have a green lottery ticket, with ints a, b, and c on it. 
         If the numbers are all different from each other, the result is 0. 
         If all of the numbers are the same, the result is 20. 
         If two of the numbers are the same, the result is 10.
         greenTicket(1, 2, 3) → 0
         greenTicket(2, 2, 2) → 20
         greenTicket(1, 1, 2) → 10
         */
        public int GreenTicket(int a, int b, int c)
        {
            if (a != b && b != c && a != c)
            {
                return 0;
            }
            if (a == b && a == c)
            {
                return 20;
            }
            return 10;
        }
    }
}

// Stuck? Here is a solution - https://vimeo.com/501566101/78c8f5a9a4
