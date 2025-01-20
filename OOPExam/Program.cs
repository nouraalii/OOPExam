using System;

namespace OOPExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime startTime = DateTime.Now;

            //Subject Id - Name
            Console.WriteLine("Enter Subject Id:");
            int SubjectId;
            while (!int.TryParse(Console.ReadLine(), out SubjectId))
            {
                Console.WriteLine("Invalid input. Please enter a valid Subject Id (integer):");
            }

            Console.WriteLine("Enter Subject Name:");
            string SubjectName = Console.ReadLine();

            //(Final or Practical)
            Console.WriteLine("Enter Exam type (1 for Final | 2 for Practical):");
            int ExamType;
            while (!int.TryParse(Console.ReadLine(), out ExamType) || (ExamType != 1 && ExamType != 2))
            {
                Console.WriteLine("Invalid input. Please enter 1 for Final or 2 for Practical:");
            }

            //exam duration and number of questions
            Console.Write("Enter Exam Time (From 30 to 180): ");
            int Time;

            while (!int.TryParse(Console.ReadLine(), out Time) || Time < 30 || Time > 180)
            {
                Console.WriteLine("Invalid input. Please enter an integer between 30 and 180:");
            }


            Console.Write("Enter Number of Questions: ");
            int NumberOfQuestions;
            while (!int.TryParse(Console.ReadLine(), out NumberOfQuestions) || NumberOfQuestions <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer for Number of Questions:");
            }

            // Initialize the exam object 
            Exam exam = null;

            if (ExamType == 1)
            {
                exam = new FinalExam(Time, NumberOfQuestions);
            }
            else
            {
                exam = new PracticalExam(Time, NumberOfQuestions);
            }

            // Initialize the questions array
            exam.Questions = new Question[NumberOfQuestions];

            // Add questions to the exam
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Console.WriteLine($"Enter details for Question {i + 1}:");

                int questionType;
                if (ExamType == 2) //If practical will choose MCQ only 
                {
                    questionType = 1; 
                }
                else
                {
                    Console.Write("Enter Question Type (1 for MCQ, 2 for True/False): ");
                    while (!int.TryParse(Console.ReadLine(), out questionType) || (questionType != 1 && questionType != 2))
                    {
                        Console.WriteLine("Invalid input. Please enter 1 for MCQ or 2 for True/False:");
                    }
                }

                //question details
                Console.Write("Enter Question Header: ");
                string header = Console.ReadLine();

                Console.Write("Enter Question Body: ");
                string body = Console.ReadLine();

                Console.Write("Enter Question Mark: ");
                int mark;
                while (!int.TryParse(Console.ReadLine(), out mark) || mark <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer for Question Mark:");
                }

                Answer[] answers = null;


                if (questionType == 1) // MCQ
                {
                    Console.WriteLine("Enter Number of Answers:");
                    int numAnswers;
                    while (!int.TryParse(Console.ReadLine(), out numAnswers) || numAnswers <= 0)
                    {
                        Console.WriteLine("Invalid input. Please enter a positive integer for Number of Answers:");
                    }

                    answers = new Answer[numAnswers];

                    for (int j = 0; j < numAnswers; j++)
                    {
                        Console.WriteLine($"Enter Answer {j + 1} Text:");
                        string answerText = Console.ReadLine();
                        answers[j] = new Answer(j + 1, answerText); // Assign Answer
                    }
                }
                else // True/False
                {
                    answers = new Answer[]
                    {
                        new Answer(1, "True"),
                        new Answer(2, "False")
                    };
                }


                Console.Write("Enter Correct Answer ID: ");
                int RightAnsId;
                while (!int.TryParse(Console.ReadLine(), out RightAnsId))
                {
                    Console.WriteLine("Invalid input. Please enter a valid Answer ID:");
                }

                Answer RightAnswer = null;
                foreach (var ans in answers)
                {
                    if (ans.AnswerId == RightAnsId)
                    {
                        RightAnswer = ans;
                        break;
                    }
                }

                
                Question question = null;
                if (questionType == 1) // MCQ
                {
                    question = new MCQ(header, body, mark, answers, RightAnswer);
                }
                else if (questionType == 2) // True/False
                {
                    question = new TrueOrFalse(header, body, mark, answers, RightAnswer);
                }

                // Add the question to the exam
                exam.Questions[i] = question;
            }


            Subject subject = new Subject(SubjectId, SubjectName);
            subject.CreateExam(exam); 

            DateTime endTime = DateTime.Now;


            subject.Exam.ShowExam();

            TimeSpan duration = endTime - startTime;
            Console.WriteLine($"Time: {duration.Minutes}.{duration.Seconds}");
        }
    }
}
