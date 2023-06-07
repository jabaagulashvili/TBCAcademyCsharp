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
       {
        Console.WriteLine("Input any positive number: ");
        int number = int.Parse(Console.ReadLine());

        int sum = 0;
        for (int i = 1; i <= number; i++)
        {
            sum += i;
        }

        int average = (int)sum / number;

        Console.WriteLine($"The sum of positive numbers is: {sum}");
        Console.WriteLine($"The arithmetic average is: {average}");
    }
 }
}
}