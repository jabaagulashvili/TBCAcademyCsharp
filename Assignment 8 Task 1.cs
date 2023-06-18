using System;

public static class Calculator
{
    public static double Add(double a, double b)
    {
        return a + b;
    }

    public static double Subtract(double a, double b)
    {
        return a - b;
    }

    public static double Multiply(double a, double b)
    {
        return a * b;
    }

    public static double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new ArgumentException("Cannot divide by zero.");
        }
        return a / b;
    }

    public static double Pow(double a, double power)
    {
        double result = 1;
        if (power > 0)
        {
            for (int i = 0; i < power; i++)
            {
                result *= a;
            }
        }
        else if (power < 0)
        {
            for (int i = 0; i > power; i--)
            {
                result /= a;
            }
        }
        return result;
    }

}

public class Program
{
    static void Main()
    {
        double number1 = 10;
        double number2 = 5;

        double sum = Calculator.Add(number1, number2);
        Console.WriteLine("sum: " + sum);

        double subtract = Calculator.Subtract(number1, number2);
        Console.WriteLine("subtract: " + subtract);

        double multiplication = Calculator.Multiply(number1, number2);
        Console.WriteLine("multiplication: " + multiplication);

        double quotient = Calculator.Divide(number1, number2);
        Console.WriteLine("Quotient: " + quotient);

        double power = Calculator.Pow(number1, number2);
        Console.WriteLine("Power: " + power);


    }
}