using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam
{
    internal class FinalExam : Exam
    {
        public FinalExam(int time, int numberofquestions) : base(time, numberofquestions)
        {
        }

        public override void ShowExam()
        {
            Console.WriteLine("Final Exam");
            int TotalMark = 0;
            int UserScore = 0;
            foreach (var question in Questions)
            {
                question.PrintQuestion();
                Console.WriteLine("Enter your Answer Id");
                int userAnswerId = int.Parse(Console.ReadLine());
                foreach (var answer in question.AnswerList)
                {
                    if (userAnswerId == question.RightAnswer.AnswerId)
                    {
                        UserScore += question.Mark; 
                        break;
                    }
                }
                Console.WriteLine($"Correct Answer ID: {question.RightAnswer.AnswerId}");
                TotalMark += question.Mark;
            }
            
            Console.WriteLine($"Your total score: {UserScore}/{TotalMark}");
        }
    }
}
