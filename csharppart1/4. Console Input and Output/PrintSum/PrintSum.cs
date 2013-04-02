using System;

class PrintSum
{
    static void Main()
    {
        int a, b, c;
        Console.Write("Enter first number: ");
        if (!int.TryParse(Console.ReadLine(), out a)) { Console.WriteLine("Invalid input!"); return; }

        Console.Write("Enter second number: ");
        if (!int.TryParse(Console.ReadLine(), out b)) { Console.WriteLine("Invalid input!"); return; }

        Console.Write("Enter third number: ");
        if (!int.TryParse(Console.ReadLine(), out c)) { Console.WriteLine("Invalid input!"); return; }

        Console.WriteLine("Sum: " + (a + b + c));
    }
}
