using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam
{
    internal class MCQ : Question
    {
        public MCQ(string header, string body, int mark, Answer[] answers, Answer rightanswer) : base(header, body, mark, answers, rightanswer)
        {
        }

        public override void PrintQuestion()
        {
            Console.WriteLine(Header);
            Console.WriteLine(Body);
            for (int i = 0; i < AnswerList.Length; i++)
            {
                Console.WriteLine($"{i+1}.{AnswerList[i].AnswerText}");
            }
        }
    }
}
