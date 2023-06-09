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
        Console.Write("Size of the first array: ");
        int size1 = int.Parse(Console.ReadLine());

        int[] array1 = new int[size1];

        
        for (int i = 0; i < size1; i++)
        {
            Console.Write($"Enter element {i + 1} of the first array: ");
            array1[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Size of the second array: ");
        int size2 = int.Parse(Console.ReadLine());

        int[] array2 = new int[size2];

        
        for (int i = 0; i < size2; i++)
        {
            Console.Write($"Enter element {i + 1} of the second array: ");
            array2[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Please choose the sort direction (ASC/DESC): ");
        string sortDirection = Console.ReadLine().ToUpper();

    
        int[] combinedArray = new int[size1 + size2];
        Array.Copy(array1, combinedArray, size1);
        Array.Copy(array2, 0, combinedArray, size1, size2);

        
        if (sortDirection == "ASC")
        {
            Array.Sort(combinedArray);
        }
        else if (sortDirection == "DESC")
        {
            Array.Sort(combinedArray);
            Array.Reverse(combinedArray);
        }
        else
        {
            Console.WriteLine("Invalid sort direction. Array not sorted.");
        }

        
        Console.WriteLine("Sorted array:");
        foreach (int number in combinedArray)
        {
            Console.WriteLine(number);
        }
    }
}
}