namespace Lecture
{
    public partial class LectureExample
    {
        /*
        12. Now write the above using the Ternary operator ?:
        */
        public string ReturnFizzIfThreeUsingTernary(int number)
        {
            // A ternary operator is used to evaluate to a single value
            // see: https://book.techelevator.com/v2_3/content/logical-branching-ool.html#conditional-code

            return (number == 3) ? "Fizz" : "";
        }
    }
}
