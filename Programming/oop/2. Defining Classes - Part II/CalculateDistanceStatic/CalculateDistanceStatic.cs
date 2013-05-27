using System;

class Program
{
    static void Main()
    {
        Point3D p1 = new Point3D(2, 1, 4);
        Point3D p2 = new Point3D(3, -1, 14);

        Console.WriteLine(DistanceCalculator.CalculateDistance(p1, p2)); 
    }
}
