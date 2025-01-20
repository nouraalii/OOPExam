using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam
{
    internal abstract class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public Answer[] AnswerList { get; set; }
        public Answer RightAnswer { get; set; }

        public Question(string header , string body , int mark , Answer[] answers , Answer rightanswer )
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = answers;
            RightAnswer = rightanswer;
        }

        public abstract void PrintQuestion();
    }
}
