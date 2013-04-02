using System;

class Program
{
    public static double AltitudeSideSurface(double side, double altitude)
    {
        return (side * altitude) / 2;
    }

    public static double ThreeSidesSurface(double a, double b, double c)
    {
        double p = (a + b + c) / 2;

        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    public static double TwoSidesAngleSurface(double a, double b, double alpha)
    {
        double radians = alpha * (Math.PI / 180);
        return (a * b * Math.Sin(radians)) / 2;
    }

    static void Main()
    {
        Console.WriteLine("a = 5.34, aha = 4.32, S = " + AltitudeSideSurface(5.34, 4.32));
        Console.WriteLine("a = 4.11, b = 3, c = 5.004, S = " + Math.Round(ThreeSidesSurface(4.11, 3, 5.004), 4));
        Console.WriteLine("a = 4.3, b = 5, alpha = 30deg, S = " + TwoSidesAngleSurface(4.3, 5, 30));
    }
}
