using System;

class PrintNotDivisibleBy3_7_Only
{
    static void Main()
    {
        int N = 20;
        for (int i = 1; i <= 20; i++)
        {
            if (i % 3 != 0 && i % 7 != 0) Console.Write(i + " ");
        }
        Console.WriteLine();
    }
}
