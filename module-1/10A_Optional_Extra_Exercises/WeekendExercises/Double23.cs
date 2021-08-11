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
         Given an int array, return true if the array contains 2 twice, 
         or 3 twice. The array will be length 0, 1, or 2.
         double23([2, 2]) → true
         double23([3, 3]) → true
         double23([2, 3]) → false
         */
        public bool Double23(int[] nums)
        {
            int count2 = 0;
            int count3 = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 2)
                {
                    count2 += 1;
                }
                if (nums[i] == 3)
                {
                    count3 += 1;
                }
            }
            if (count2 >= 2 || count3 >= 2)
            {
                return true;
            }
            return false;
        }
    }
}

// Stuck? - Here is a solution - https://vimeo.com/501471206/b8efbb029f