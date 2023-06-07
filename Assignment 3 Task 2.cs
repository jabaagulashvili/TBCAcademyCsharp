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
        Console.WriteLine("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        int divisorCount = CountDivisors(number);

        Console.WriteLine($"The number {number} has {divisorCount} divisor(s).");
    }

    static int CountDivisors(int number)
    {
        int count = 0;

        
        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
            {
                count++;
            }
        }

        return count;
    }
   }
}