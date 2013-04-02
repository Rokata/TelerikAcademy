using System;

class PointWithinCircle
{
    static void Main()
    {
        int center_x = 0, center_y = 0, radius = 5;
        Console.Write("Enter x coord: ");
        double x = double.Parse(Console.ReadLine());
        Console.Write("Enter y coord: ");
        double y = double.Parse(Console.ReadLine());

        if (Math.Pow(x - center_x, 2) + Math.Pow(y - center_y, 2) < Math.Pow(radius, 2))
        {
            Console.WriteLine("Within circle");
        }
        else Console.WriteLine("Outside circle");
    }
}
