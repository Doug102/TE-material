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
         Given three ints, a b c, return true if one of them is 10 or more less 
         than one of the others.
         lessBy10(1, 7, 11) → true
         lessBy10(1, 7, 10) → false
         lessBy10(11, 1, 7) → true
         */
        public bool LessBy10(int a, int b, int c)
        {
            if (a - b >= 10 || a - b <= -10)
            {
                return true;
            }
            if (b - c >= 10 || b - c <= -10)
            {
                return true;
            }
            if (a - c >= 10 || a - c <= -10)
            {
                return true;
            }
            return false;
        }
    }
}

//Stuck? - Here is a solution - https://vimeo.com/501576105/e3b1168162
