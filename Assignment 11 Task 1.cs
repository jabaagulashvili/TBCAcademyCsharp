using System;


interface Calculator<T>
{
    T Add(T num1, T num2);
    T Subtract(T num1, T num2);
    T Multiply(T num1, T num2);
}


class IntegerCalculator : Calculator<int>
{
    public int Add(int num1, int num2)
    {
        return num1 + num2;
    }

    public int Subtract(int num1, int num2)
    {
        return num1 - num2;
    }

    public int Multiply(int num1, int num2)
    {
        return num1 * num2;
    }
}


class DoubleCalculator : Calculator<double>
{
    public double Add(double num1, double num2)
    {
        return num1 + num2;
    }

    public double Subtract(double num1, double num2)
    {
        return num1 - num2;
    }

    public double Multiply(double num1, double num2)
    {
        return num1 * num2;
    }
}

class Program
{
    static void Main()
    {

        Calculator<int> intCalculator = new IntegerCalculator();
        int result = intCalculator.Add(5, 3);
        Console.WriteLine("Addition result: " + result);

        result = intCalculator.Subtract(8, 2);
        Console.WriteLine("Subtraction result: " + result);

        result = intCalculator.Multiply(4, 6);
        Console.WriteLine("Multiplication result: " + result);


        Calculator<double> doubleCalculator = new DoubleCalculator();
        double doubleResult = doubleCalculator.Add(2.5, 3.7);
        Console.WriteLine("Addition result: " + doubleResult);

        doubleResult = doubleCalculator.Subtract(5.9, 2.1);
        Console.WriteLine("Subtraction result: " + doubleResult);

        doubleResult = doubleCalculator.Multiply(1.5, 4.2);
        Console.WriteLine("Multiplication result: " + doubleResult);
    }
}