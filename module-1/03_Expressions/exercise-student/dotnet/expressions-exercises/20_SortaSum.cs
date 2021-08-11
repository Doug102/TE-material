namespace Exercises
{
    public partial class Exercises
    {

        /*
         Given 2 ints, a and b, return their sum. However, sums in the range 10..19 inclusive, are forbidden,
         so in that case just return 20.
         SortaSum(3, 4) → 7
         SortaSum(9, 4) → 20
         SortaSum(10, 11) → 21
         */
        public int SortaSum(int a, int b)
        {
            if (a + b >= 10 && a + b <=19)
            {
                return 20;
            }
            else
            {
                return a + b;
            }
            return 0;
        }
    }
}
