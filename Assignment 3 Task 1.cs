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

          if (IsPrime(number))
          {
            Console.WriteLine($"{number} is a prime number.");
          }
            else
          {
            Console.WriteLine($"{number} is a composite number.");
          }
    }

    static bool IsPrime(int number)
    {
        if (number <= 1)
        {
            return false;
        }

        
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }
   }
}






