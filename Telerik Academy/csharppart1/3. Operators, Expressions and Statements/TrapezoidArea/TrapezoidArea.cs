using System;

class TrapezoidArea
{
    static void Main()
    {
        Console.Write("a=? ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("b=? ");
        int b = int.Parse(Console.ReadLine());
        Console.Write("h=? ");
        int h = int.Parse(Console.ReadLine());
        Console.WriteLine("Area: " + (double)((a + b) * h) / 2);
    }
}
