using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QuizMaker
{
    public class IOWork
    {
        public bool ValidPath(string fullPath)
        {
            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {

                }
            }
            catch (IOException)
            {
                return false;
            }
            return true;
        }

        public Dictionary<int, Question> TestSetup(string fullPath)
        {
            Dictionary<int, Question> questionList = new Dictionary<int, Question>();
            using (StreamReader sr = new StreamReader(fullPath))
            {
                int counter = 1;

                while (!sr.EndOfStream)
                {
                    Question question = new Question();
                    string line = sr.ReadLine();

                    string[] parts = line.Split('|');
                    question.Query = parts[0];
                    question.Answer1 = parts[1].Replace('*', ' ');
                    question.Answer2 = parts[2].Replace('*', ' ');
                    question.Answer3 = parts[3].Replace('*', ' ');
                    question.Answer4 = parts[4].Replace('*', ' ');
                    for (int i = 0; i < parts.Length; i++)
                    {
                        if (parts[i].Contains('*'))
                        {
                            string temp = parts[i].Replace('*', ' ');
                            question.CorrectAnswer = temp;
                            break;
                        }
                    }
                    questionList.Add(counter, question);
                    counter++;



                }
            }
            return questionList;
        }
    }
}
