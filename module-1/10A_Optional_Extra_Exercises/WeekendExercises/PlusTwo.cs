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
         Given 2 int arrays, each length 2, return a new array length 4 containing all their elements.
         plusTwo([1, 2], [3, 4]) → [1, 2, 3, 4]
         plusTwo([4, 4], [2, 2]) → [4, 4, 2, 2]
         plusTwo([9, 2], [3, 4]) → [9, 2, 3, 4]
         */
        public int[] PlusTwo(int[] a, int[] b)
        {
            return new int[] 
            {
                a[0],
                a[1],
                b[0],
                b[1]
            };
        }
    }
}

// Stuck?  - Here is a solution - https://vimeo.com/501985517/7dd99c6f50