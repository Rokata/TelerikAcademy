using System;

class PointWithinCircleAndRectangle
{
    static void Main()
    {
        double center_x = 1, center_y = 1, radius = 3, top = 1, left = -1, width = 6, height = 2;
        Console.WriteLine("Point x: ");
        double point_x = double.Parse(Console.ReadLine());
        Console.WriteLine("Point y: ");
        double point_y = double.Parse(Console.ReadLine());

        if (Math.Pow(point_x - center_x, 2) + Math.Pow(point_y - center_y, 2) < Math.Pow(radius, 2) &&
            (point_x < top || point_x > top + width) && (point_y < left || point_y > left + height))
        {
            Console.WriteLine("The point is within circle K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2).");
        }
        else Console.WriteLine("Point does not satisfy the requirement.");
    }
}
