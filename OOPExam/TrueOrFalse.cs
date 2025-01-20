using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam
{
    internal class TrueOrFalse : Question
    {
        public TrueOrFalse(string header, string body, int mark, Answer[] answers, Answer rightanswer) : base(header, body, mark, answers, rightanswer)
        {
        }

        public override void PrintQuestion()
        {
            Console.WriteLine(Header);
            Console.WriteLine(Body);
            Console.WriteLine("1. True");
            Console.WriteLine("2. False");
        }
    }
}
