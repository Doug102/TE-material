namespace Exercises
{
    public partial class Exercises
    {
        /*
         Given an array of ints, return true if the array contains a 2 next to a 2 somewhere.
         Has22([1, 2, 2]) → true
         Has22([1, 2, 1, 2]) → false
         Has22([2, 1, 2]) → false
         */
        public bool Has22(int[] nums)
        {
            for (int i = 1; i < nums.Length - 1; i++)
            {
                if (nums[i] == 2 && (nums[i - 1] == 2 || nums [i + 1] == 2))
                {
                    return true;
                }
                
            }
            if ((nums[0] == 2 && nums[1] == 2))
            {
                return true;
            }
            else if (nums[nums.Length - 1] == 2 && nums[nums.Length - 2] == 2)
            {
                return true;
            }
            return false;
        }
    }
}
