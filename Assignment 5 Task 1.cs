using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TbcAcademy
{
    public class Excersice
    {
        static void Main(string[] args)
        {
            int[] numbers = { 123, 555, 999 };
            int index = 1;
            int digitSum = GetDigitSum(numbers, index);
            Console.WriteLine($"The sum of digits at index {index} is: {digitSum}");
        }

        static int GetDigitSum(int[] numbers, int index)
        {


            int number = numbers[index];
            int sum = 0;

            while (number > 0)
            {
                int digit = number % 10;
                sum += digit;
                number /= 10;
            }

            return sum;
        }
    }
}
    