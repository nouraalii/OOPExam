using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam
{
    internal class PracticalExam : Exam
    {
        public PracticalExam(int time, int numberofquestions) : base(time, numberofquestions)
        {
        }

        public override void ShowExam()
        {
            Console.WriteLine("Practical Exam");
            foreach (var question in Questions)
            {
                question.PrintQuestion();

                Console.WriteLine("Enter your Answer ID: ");
                int userAnswerId = int.Parse(Console.ReadLine());

                Console.WriteLine($"Correct Answer ID: {question.RightAnswer.AnswerId}");
            }
        }
    }
}
