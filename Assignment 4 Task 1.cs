using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TbcAcademy
{
    public class Excersice
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter the size of the array: ");
        int size = int.Parse(Console.ReadLine());

        int[] numbers = new int[size];

        
        for (int x = 0; x < size; x++)
        {
            Console.Write($"Enter element {x + 1}: ");
            numbers[x] = int.Parse(Console.ReadLine());
        }

        
        for (int x = 0; x < size - 1; x++)
        {
            for (int y = 0; y < size - x - 1; y++)
            {
                if (numbers[y] > numbers[y + 1])
                {
                    
                    int temp = numbers[y];
                    numbers[y] = numbers[y + 1];
                    numbers[y + 1] = temp;
                }
            }
        }

        
        Console.WriteLine("Sorted array:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
           
        }
    }
}
