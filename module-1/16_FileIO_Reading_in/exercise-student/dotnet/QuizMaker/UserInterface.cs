using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QuizMaker
{
    public class UserInterface
    {
        public void UI()
        {
            while (true)
            {
                Console.WriteLine("Enter the fully qualified name of the file to ready in for quiz questions:");
                string fullPath = Console.ReadLine();
                IOWork file = new IOWork();
                bool validPath = file.ValidPath(fullPath);
               if (!validPath)
                {
                    Console.WriteLine("No file found at the name given, please try again.");
                }
                else
                {
                    Dictionary<int, Question> questionList = new Dictionary<int, Question>();
                    questionList = file.TestSetup(fullPath);


                    Console.WriteLine(questionList[1].Query);
                    Console.WriteLine(questionList[1].Answer1);
                    Console.WriteLine(questionList[1].Answer2);
                    Console.WriteLine(questionList[1].Answer3);
                    Console.WriteLine(questionList[1].Answer4);
                    Console.WriteLine(questionList[1].CorrectAnswer);



                }
            }
        }
    }
}
