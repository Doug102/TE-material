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
         Given an array of ints, return true if the number of 1's is 
         greater than the number of 4's
         more14([1, 4, 1]) → true
         more14([1, 4, 1, 4]) → false
         more14([1, 1]) → true
         */
        public bool More14(int[] nums)
        {
            int num4 = 0;
            int num1 = 0;
            
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    num1 += 1;
                }
                if (nums[i] == 4)
                {
                    num4 += 1;
                }

                
            }
            if (num1 > num4)
            {
                return true;
            }
            return false;
        }
    }
}

// Stuck? - Here is a solution - https://vimeo.com/501882394/a44883058e
