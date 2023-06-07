using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TbcAcademy

{
   public class Excercise
   {
      public static void Main(string[] args)
{
        bool ContinueGame = true;

        while (ContinueGame)
        {
            Console.Write("Please Enter the First number in the range: ");
            int FirstNumber = int.Parse(Console.ReadLine());

            Console.Write("Please Enter the Last number in the range: ");
            int LastNumber = int.Parse(Console.ReadLine());

            int randomNumber = GenerateRandomNumber(FirstNumber, LastNumber);
            int guessCount = 0;
            int guess;
            bool GuessedCorrectly = false;

            Console.WriteLine($"Guess a number between {FirstNumber} and {LastNumber}.");

            while (!GuessedCorrectly)
            {
                Console.Write("Enter your guess: ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (guess < randomNumber)
                {
                    Console.WriteLine("Wrong Number,Please Try again");
                }
                else if (guess > randomNumber)
                {
                    Console.WriteLine("Wrong Number,Please Try again");
                }
                else
                {
                    Console.WriteLine($"Congratulations! Your Guess {randomNumber} Is correct. You guessed it in {guessCount} tries.");
                    GuessedCorrectly = true;
                }
            }

            Console.Write("Do you want to continue? (Yes/No): ");
            string ContinueResponse = Console.ReadLine();

            if (ContinueResponse.ToLower() != "yes")
            {
                ContinueGame = false;
            }

            Console.WriteLine();
        }
    }

    static int GenerateRandomNumber(int FirstNumber, int LastNumber)
    {
        Random random = new Random();
        return random.Next(FirstNumber, LastNumber + 1);
    }
   }
}