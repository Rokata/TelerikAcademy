using System;

class DisplayNumber
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine("Decimal: {0,15:D}", number);
        Console.WriteLine("Percentage: {0,15:P}", number);
        Console.WriteLine("Hex: {0,15:X}", number);
        Console.WriteLine("Scientifc: {0,15:E}", number);
    }
}
