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
           Console.Write("Enter the size of the FirstArray: ");
        int size1 = int.Parse(Console.ReadLine());

        string[] FirstArray = new string[size1];

        for (int i = 0; i < size1; i++)
        {
            Console.Write($"Enter element {i + 1} of the FirstArray: ");
            FirstArray[i] = Console.ReadLine();
        }

        Console.Write("Enter the size of the SecondArray: ");
        int size2 = int.Parse(Console.ReadLine());

        int[] SecondArray = new int[size2];

        for (int i = 0; i < size2; i++)
        {
            Console.Write($"Enter element {i + 1} of the SecondArray: ");
            SecondArray[i] = int.Parse(Console.ReadLine());
        }

        string[] ConcatenatedArray = new string[size1 + size2];

        
        int index = 0;
        for (int i = 0; i < Math.Min(size1, size2); i++)
        {
            ConcatenatedArray[index] = FirstArray[i] + SecondArray[i];
            index++;
        }

        for (int i = Math.Min(size1, size2); i < size1; i++)
        {
            ConcatenatedArray[index] = FirstArray[i];
            index++;
        }

        for (int i = Math.Min(size1, size2); i < size2; i++)
        {
            ConcatenatedArray[index] = SecondArray[i].ToString();
            index++;
        }

        Console.WriteLine("Concatenated array:");
        string result = string.Join(", ", ConcatenatedArray);
        Console.WriteLine(result);
    }
}
}