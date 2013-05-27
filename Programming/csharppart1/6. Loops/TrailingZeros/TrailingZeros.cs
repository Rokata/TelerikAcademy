using System;

class TrailingZeros
{
    static void Main()
    {
        int N = 50000;
        int multiples;
        int fivePowered = 5;
        int zeros = 0;

        do
        {
            multiples = N / fivePowered;
            fivePowered *= 5;
            zeros += multiples;
        } while (multiples > 0);

        Console.WriteLine("{0}! has {1} trailiing zeros.", N, zeros);
    }
}
