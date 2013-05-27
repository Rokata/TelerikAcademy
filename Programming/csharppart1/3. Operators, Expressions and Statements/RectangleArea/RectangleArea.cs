using System;

class RectangleArea
{
    static void Main()
    {
        Console.Write("Width: ");
        int width = int.Parse(Console.ReadLine());
        Console.Write("Height: ");
        int height = int.Parse(Console.ReadLine());

        Console.WriteLine("Area: " + (width * height));
    }
}
