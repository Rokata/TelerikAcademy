using System;

class Fibonacci
{
    static void Main()
    {
        int N = 12;
        int lastButOne = 0, last = 1;
        int current = 1;

        for (int i = 3; i <= N; i++)
        {
            current = last + lastButOne;
            lastButOne = last;
            last = current;
        }

        Console.WriteLine("Fibonacci's {0}th number is: {1}", N, current);
    }
}
