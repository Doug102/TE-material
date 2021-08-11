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
         Given an array of ints, we'll say that a triple is a value appearing 3 
         times in a row in the array. Return true if the array does not 
         contain any triples. Return false otherwise.
         noTriples([1, 1, 2, 2, 1]) → true
         noTriples([1, 1, 2, 2, 2, 1]) → false
         noTriples([1, 1, 1, 2, 2, 2, 1]) → false
         */
        public bool NoTriples(int[] nums)
        {
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (nums[i] == nums[i + 1] && nums[i + 2] == nums[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}

//Stuck? - Here is a solution - https://vimeo.com/501972356/618ca884f4
