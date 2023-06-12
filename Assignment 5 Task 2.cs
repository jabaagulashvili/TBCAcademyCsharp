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
            char[] array = GetFilledArray();
            char symbol = GetSymbol();
            int occurrenceCount = NumberOfSymbolContainment(array, symbol);
            PrintResult(symbol, occurrenceCount);
        }

        static char[] GetFilledArray()
        {
            Console.Write("Size of the array: ");
            int size = int.Parse(Console.ReadLine());
            char[] array = new char[size];

            for (int i = 0; i < size; i++)
            {
                Console.Write($"Enter an element {i + 1}: ");
                array[i] = Console.ReadLine()[0];
            }

            return array;
        }

        static char GetSymbol()
        {
            Console.Write("Enter a symbol: ");
            char symbol = Console.ReadLine()[0];
            return symbol;
        }

        static int NumberOfSymbolContainment(char[] array, char symbol)
        {
            int count = 0;

            foreach (char element in array)
            {
                if (element == symbol)
                {
                    count++;
                }
            }

            return count;
        }

        static void PrintResult(char symbol, int count)
        {
            Console.WriteLine($"Symbol '{symbol}' shegvxvda {count} times.");
        }
    }
}