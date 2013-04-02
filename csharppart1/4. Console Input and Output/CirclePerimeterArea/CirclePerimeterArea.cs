using System;

class CirclePerimeterArea
{
    static void Main()
    {
        double r;
        Console.Write("Enter radius: ");
        if (!double.TryParse(Console.ReadLine(), out r)) { Console.WriteLine("Invalid input!"); return; } 

        Console.WriteLine("Perimeter: {0} \nArea: {1}", Math.Round((2 * Math.PI * r), 4), Math.Round((Math.PI * r * r), 4));
    }
}
