using System;

namespace CalculatorApp
{
    class Program
    {
        delegate double MathOperation(double x, double y);

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Calculator!");

            while (true)
            {
                Console.WriteLine("Choose a mathematical operation:");
                Console.WriteLine("1. Addition");
                Console.WriteLine("2. Subtraction");
                Console.WriteLine("3. Multiplication");
                Console.WriteLine("4. Division");
                Console.WriteLine("5. Square Root");
                Console.WriteLine("6. Exponentiation");
                Console.WriteLine("7. Exit");

                int option;
                if (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 7)
                {
                    Console.WriteLine("Invalid option. Please try again.");
                    continue;
                }

                if (option == 7)
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

                MathOperation operation;

                switch (option)
                {
                    case 1:
                        operation = (x, y) => x + y;
                        break;
                    case 2:
                        operation = (x, y) => x - y;
                        break;
                    case 3:
                        operation = (x, y) => x * y;
                        break;
                    case 4:
                        operation = (x, y) => x / y;
                        break;
                    case 5:
                        operation = (x, y) => Math.Sqrt(x);
                        break;
                    case 6:
                        operation = (x, y) => Math.Pow(x, y);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        continue;
                }

                Console.WriteLine("Enter the first number:");
                if (!double.TryParse(Console.ReadLine(), out double num1))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                if (option != 5)
                {
                    Console.WriteLine("Enter the second number:");
                    if (!double.TryParse(Console.ReadLine(), out double num2))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                        continue;
                    }

                    double result = operation(num1, num2);
                    Console.WriteLine($"Result: {result}");
                }
                else
                {
                    double result = operation(num1, 2);
                    Console.WriteLine($"Result: {result}");
                }
            }
        }
    }
}
