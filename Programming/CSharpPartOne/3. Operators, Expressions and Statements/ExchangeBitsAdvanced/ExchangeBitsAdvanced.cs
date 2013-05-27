using System;

class ExchangeBitsAdvanced
{
    static void Main()
    {
        uint n = 264;

        Console.WriteLine(Convert.ToString(n, 2));

        byte p = 3;
        byte q = 2;
        byte k = 21;
        uint mask = 1;

        for (int i = 0; i < p; i++)
        {
            mask *= 2;
        }

        uint getFirstBits = (((mask - 1) << q) & n) >> q;
        uint getSecondBits = (((mask - 1) << k) & n) >> k;

        n = n & (~((mask - 1) << q));
        n = n & (~((mask - 1) << k));

        n = n | (getFirstBits << k);

        n = n | (getSecondBits << q);

        Console.WriteLine(Convert.ToString(n, 2));
    }
}