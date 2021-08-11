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
         Given an array of ints, return true if it contains no 1's and 
         it contains no 4's.
         no14([5, 2, 3]) → true
         no14([1, 2, 3, 4]) → false
         no14([2, 3, 4]) → false
         */
        public bool No14(int[] nums)
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
            if (num1 == 0 && num4 == 0)
            {
                return true;
            }
            return false;
        }
    }
}

//Stuck? - Here is a solution - https://vimeo.com/501969520/b68af986eb
