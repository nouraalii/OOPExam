using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam
{
    internal abstract class Exam
    {
        private int time;

        public int Time
        {
            get { return time; }
            set
            {
                if (value >= 30 && value <= 180)
                {
                    time = value;
                }
                else
                {
                    Console.WriteLine("Invalid time. Please enter a value between 30 and 180.");
                }
            }
        }

        public int NumberOfQuestions { get; set; }
        public Question[] Questions { get; set; }

        public Exam(int time , int numberofquestions )
        {
            Time = time;
            NumberOfQuestions = numberofquestions;
        }

        public abstract void ShowExam();
    }
}
