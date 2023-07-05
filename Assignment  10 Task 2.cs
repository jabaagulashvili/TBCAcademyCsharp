using System;

class Triangle
{
    private double sideA;
    private double sideB;
    private double sideC;

    public Triangle(double a, double b, double c)
    {
        if (a <= 0 || b <= 0 || c <= 0)
            throw new ArgumentException("Triangle sides must be greater than zero.");
        
        sideA = a;
        sideB = b;
        sideC = c;
    }

    public double Area()
    {
        
        double s = (sideA + sideB + sideC) / 2;
        return Math.Sqrt(s * (s - sideA) * (s - sideB) * (s - sideC));
    }

    public double Perimeter()
    {
        return sideA + sideB + sideC;
    }

    public static bool operator ==(Triangle t1, Triangle t2)
    {
        if (ReferenceEquals(t1, null) && ReferenceEquals(t2, null))
            return true;

        if (ReferenceEquals(t1, null) || ReferenceEquals(t2, null))
            return false;

        return t1.Area() == t2.Area();
    }

    public static bool operator !=(Triangle t1, Triangle t2)
    {
        return !(t1 == t2);
    }

    public static bool operator >(Triangle t1, Triangle t2)
    {
        return t1.Area() > t2.Area();
    }

    public static bool operator <(Triangle t1, Triangle t2)
    {
        return t1.Area() < t2.Area();
    }

    public static Triangle operator +(Triangle t1, Triangle t2)
    {
        double totalArea = t1.Area() + t2.Area();
        double sideLength = Math.Sqrt(totalArea / Math.Sqrt(3)); 

        return new Triangle(sideLength, sideLength, sideLength);
    }

    public static explicit operator Triangle(double sideLength)
    {
        return new Triangle(sideLength, sideLength, sideLength);
    }
}

class Assignment
{
    static void Main()
    {
        Console.WriteLine("Enter sides of Triangle 1:");
        double side1 = Convert.ToDouble(Console.ReadLine());
        double side2 = Convert.ToDouble(Console.ReadLine());
        double side3 = Convert.ToDouble(Console.ReadLine());
        Triangle triangle1 = new Triangle(side1, side2, side3);

        Console.WriteLine("Enter sides of Triangle 2:");
        side1 = Convert.ToDouble(Console.ReadLine());
        side2 = Convert.ToDouble(Console.ReadLine());
        side3 = Convert.ToDouble(Console.ReadLine());
        Triangle triangle2 = new Triangle(side1, side2, side3);

        Console.WriteLine("Triangle 1 Area: " + triangle1.Area());
        Console.WriteLine("Triangle 1 Perimeter: " + triangle1.Perimeter());
        Console.WriteLine("Triangle 2 Area: " + triangle2.Area());
        Console.WriteLine("Triangle 2 Perimeter: " + triangle2.Perimeter());

        Console.WriteLine("Triangle 1 == Triangle 2: " + (triangle1 == triangle2));
        Console.WriteLine("Triangle 1 != Triangle 2: " + (triangle1 != triangle2));
        Console.WriteLine("Triangle 1 > Triangle 2: " + (triangle1 > triangle2));
        Console.WriteLine("Triangle 1 < Triangle 2: " + (triangle1 < triangle2));

        Triangle triangle3 = triangle1 + triangle2;
        Console.WriteLine("Triangle 3 (Result of Addition): " + "Area: " + triangle3.Area() + ", Perimeter: " + triangle3.Perimeter());

        Console.WriteLine("Enter a side length for an equilateral triangle:");
        double sideLength = Convert.ToDouble(Console.ReadLine());
        Triangle equilateralTriangle = (Triangle)sideLength;
        Console.WriteLine("Equilateral Triangle Area: " + equilateralTriangle.Area());
        Console.WriteLine("Equilateral Triangle Perimeter: " + equilateralTriangle.Perimeter());
    }
}
