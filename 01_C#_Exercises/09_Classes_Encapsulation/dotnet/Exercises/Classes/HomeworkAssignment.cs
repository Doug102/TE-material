namespace Exercises.Classes
{
    public class HomeworkAssignment
    {
        public int EarnedMarks { get; set; }
        public int PossibleMarks { get; private set; }
        public string SubmitterName { get; private set; }
        public string LetterGrade 
        {
            get
            {
                double grade = (double)EarnedMarks / PossibleMarks;
                if (grade >= 0.90)
                {
                    return "A";
                }
                else if (grade >= 0.80)
                {
                    return "B";
                }
                else if (grade >= 0.70)
                {
                    return "C";
                }
                else if (grade >= 0.60)
                {
                    return "D";
                }
                else
                {
                    return "F";
                }
                

                
            }
        }
        public HomeworkAssignment(int possibleMarks, string submitterName)
        {
            SubmitterName = submitterName;
            PossibleMarks = possibleMarks;
        }



    }
}
