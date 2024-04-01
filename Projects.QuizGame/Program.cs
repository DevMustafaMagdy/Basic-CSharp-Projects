using System.Xml;

namespace Projects.QuizGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] questions =
            {
                "1. What is the capital of Canada?",
                "2. What is the longest river in the world?",
                "3. What country has the most natural lakes",
                "4. In which continent is the Amazon Rainforest located?",
                "5. What is the smallest country in the world?"
            };
            string[] answers =
            {
                "Ottawa",
                "The Nile",
                "Canada",
                "South America",
                "Vatican City"
            };
            int rightAnswersCounter = 0;

            Console.WriteLine("Welcome to Quiz Game");
            Console.WriteLine("--------------------");

            for (int i = 0; i < questions.Length; i++)
            {
                try
                {
                    Console.WriteLine(questions[i]);
                    var userAnswer = Console.ReadLine().ToLower();
                    if (IsRightAnswer(userAnswer, answers[i].ToLower()))
                    {
                        Console.WriteLine("Excellent! Right Answer");
                        rightAnswersCounter++;
                    }
                    else
                        Console.WriteLine("Unfortunately! Wrong Answer");
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }

            }

            Console.WriteLine("--------------------------");
            Console.WriteLine("The Quiz Game is Finished");
            Console.WriteLine($"Your Score is {rightAnswersCounter} of {questions.Length}");
            Console.WriteLine($"Your Score Percentage is {(float)rightAnswersCounter / questions.Length * 100}%");
        }

        static bool IsRightAnswer(string userAnswer, string modelAnswer)
        {
            if (string.IsNullOrEmpty(userAnswer))
                throw new Exception("The Answer Can not be empty!");
            if (userAnswer == modelAnswer)
            {
                return true;
            }
            else
                return false;
        }
    }
}
