using System;
using System.Collections.Generic;
using System.IO;

namespace QuizApp
{
    public class QuizQuestion
    {
        public string Question { get; set; }
        public int Points { get; set; }
        public List<string> PossibleAnswers { get; set; }
        public int CorrectAnswerIndex { get; set; }

        public QuizQuestion()
        {
            PossibleAnswers = new List<string>();
        }
    }
}

namespace QuizApp
{
    public class Quiz
    {
        public string QuizName { get; set; }
        public List<QuizQuestion> Questions { get; set; }

        public Quiz()
        {
            Questions = new List<QuizQuestion>();
        }

        public void ClearQuestions()
        {
            Questions.Clear();
        }

        public void AddQuestion(QuizQuestion question)
        {
            Questions.Add(question);
        }

        public void SaveToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(QuizName);
                foreach (var question in Questions)
                {
                    writer.WriteLine(question.Question);
                    writer.WriteLine(question.Points);
                    writer.WriteLine(question.PossibleAnswers.Count);
                    foreach (var answer in question.PossibleAnswers)
                    {
                        writer.WriteLine(answer);
                    }
                    writer.WriteLine(question.CorrectAnswerIndex);
                }
            }
        }

        public static Quiz LoadFromFile(string filePath)
        {
            Quiz quiz = new Quiz();
            using (StreamReader reader = new StreamReader(filePath))
            {
                quiz.QuizName = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    QuizQuestion question = new QuizQuestion();
                    question.Question = reader.ReadLine();
                    question.Points = int.Parse(reader.ReadLine());
                    int numPossibleAnswers = int.Parse(reader.ReadLine());
                    for (int i = 0; i < numPossibleAnswers; i++)
                    {
                        question.PossibleAnswers.Add(reader.ReadLine());
                    }
                    question.CorrectAnswerIndex = int.Parse(reader.ReadLine());
                    quiz.AddQuestion(question);
                }
            }
            return quiz;
        }
    }
}


namespace QuizApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Quiz Application!");

            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Create a Quiz");
                Console.WriteLine("2. Fill out a Quiz");
                Console.WriteLine("3. Exit");

                int option;
                if (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 3)
                {
                    Console.WriteLine("Invalid option. Please try again.");
                    continue;
                }

                if (option == 1)
                {
                    CreateQuiz();
                }
                else if (option == 2)
                {
                    FillQuiz();
                }
                else if (option == 3)
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
            }
        }

        private static void CreateQuiz()
        {
            Console.WriteLine("Creating a new Quiz...");

            Quiz quiz = new Quiz();

            Console.WriteLine("Enter the name of the Quiz:");
            quiz.QuizName = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("Do you want to clear existing questions? (Y/N)");
                string clearOption = Console.ReadLine().ToLower();
                if (clearOption == "y")
                {
                    quiz.ClearQuestions();
                }

                QuizQuestion question = new QuizQuestion();

                Console.WriteLine("Enter the question:");
                question.Question = Console.ReadLine();

                Console.WriteLine("Enter the score for this question:");
                if (!int.TryParse(Console.ReadLine(), out int score))
                {
                    Console.WriteLine("Invalid input. Score must be an integer. Try again.");
                    continue;
                }
                question.Points = score;

                Console.WriteLine("Enter the number of possible answers:");
                if (!int.TryParse(Console.ReadLine(), out int numAnswers) || numAnswers <= 0)
                {
                    Console.WriteLine("Invalid input. Number of answers must be a positive integer. Try again.");
                    continue;
                }

                for (int i = 0; i < numAnswers; i++)
                {
                    Console.WriteLine($"Enter possible answer {i + 1}:");
                    question.PossibleAnswers.Add(Console.ReadLine());
                }

                Console.WriteLine("Enter the index (1-based) of the correct answer:");
                if (!int.TryParse(Console.ReadLine(), out int correctAnswerIndex) || correctAnswerIndex < 1 || correctAnswerIndex > numAnswers)
                {
                    Console.WriteLine("Invalid input. Index of the correct answer must be a valid choice. Try again.");
                    continue;
                }
                question.CorrectAnswerIndex = correctAnswerIndex - 1; 

                quiz.AddQuestion(question);

                Console.WriteLine("Do you want to add another question? (Y/N)");
                string addAnother = Console.ReadLine().ToLower();
                if (addAnother != "y")
                {
                    break;
                }
            }

            
            string filePath = $"{quiz.QuizName}.quiz";
            quiz.SaveToFile(filePath);
            Console.WriteLine($"Quiz '{quiz.QuizName}' has been created and saved to '{filePath}'.");
        }

        private static void FillQuiz()
        {
            Console.WriteLine("Enter the name of the Quiz you want to fill:");
            string quizName = Console.ReadLine();
            string filePath = $"{quizName}.quiz";

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Quiz '{quizName}' does not exist.");
                return;
            }

            Quiz quiz = Quiz.LoadFromFile(filePath);

            Console.WriteLine($"Filling out the Quiz '{quiz.QuizName}'...");

            int totalScore = 0;

            foreach (var question in quiz.Questions)
            {
                Console.WriteLine(question.Question);

                for (int i = 0; i < question.PossibleAnswers.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {question.PossibleAnswers[i]}");
                }

                Console.WriteLine("Enter the index (1-based) of the correct answer:");
                if (!int.TryParse(Console.ReadLine(), out int userAnswer) || userAnswer < 1 || userAnswer > question.PossibleAnswers.Count)
                {
                    Console.WriteLine("Invalid input. Please enter a valid choice.");
                    return;
                }

                if (userAnswer - 1 == question.CorrectAnswerIndex)
                {
                    totalScore += question.Points;
                }
            }

            Console.WriteLine($"Your total score for the Quiz '{quiz.QuizName}' is: {totalScore}");

           
            Console.WriteLine("Enter your first name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter your last name:");
            string lastName = Console.ReadLine();

            string resultFilePath = $"{firstName}_{lastName}_{quizName}_result.txt";
            using (StreamWriter writer = new StreamWriter(resultFilePath))
            {
                writer.WriteLine($"Quiz: {quiz.QuizName}");
                writer.WriteLine($"Name: {firstName} {lastName}");
                writer.WriteLine($"Score: {totalScore}");
            }

            Console.WriteLine($"Quiz result saved to '{resultFilePath}'.");
        }
    }
}

