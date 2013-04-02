using System;

class PrintGreaterNumber
{
    static void Main()
    {
        int first, second;

        Console.WriteLine("Enter first number: ");
        if (!int.TryParse(Console.ReadLine(), out first)) { Console.WriteLine("Invalid input!"); return; }

        Console.WriteLine("Enter second number: ");
        if (!int.TryParse(Console.ReadLine(), out second)) { Console.WriteLine("Invalid input!"); return; }

        Console.WriteLine("The greater number is " + ((first > second) ? first : second));
    }
}
