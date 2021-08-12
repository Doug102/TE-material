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
         Given an array of ints, return a new array length 2 containing the 
         first and last elements from the original array. 
         The original array will be length 1 or more.
         makeEnds([1, 2, 3]) → [1, 3]
         makeEnds([1, 2, 3, 4]) → [1, 4]
         makeEnds([7, 4, 6, 2]) → [7, 2]
         */
        public int[] MakeEnds(int[] nums)
        {
            int[] result = new int[2];
            if (nums.Length == 1)
            {
                result[0] = nums[0];
                result[1] = nums[0];
            }
            else
            {
                result[0] = nums[0];
                result[1] = nums[nums.Length - 1];
            }
            return result;
        }
    }
}

//Stuck? - Here is a solution - https://vimeo.com/501579851/9a80f6760e