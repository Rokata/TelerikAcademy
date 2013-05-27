using System;

class DivisibleByFiveInInterval
{
    static void Main()
    {
        int p = 0;
        uint first, second;

        Console.WriteLine("Enter first number: ");
        if (!uint.TryParse(Console.ReadLine(), out first))
        {
            Console.WriteLine("Invalid input!");
            return;
        }

        Console.WriteLine("Enter second number: ");
        if (!uint.TryParse(Console.ReadLine(), out second))
        {
            Console.WriteLine("Invalid input!");
            return;
        }

        for (uint current = first; current <= second; current++)
        {
            if (current % 5 == 0) p++;
        }

        Console.WriteLine("There are {0} numbers divisible by 5 in the interval", p);
    }
}
