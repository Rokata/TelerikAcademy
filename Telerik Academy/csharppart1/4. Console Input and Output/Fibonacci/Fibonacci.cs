using System;
using System.Numerics;

class Fibonacci
{
    static void Main()
    {
        int N = 100;
        BigInteger lastButOne = 0, last = 1;
        BigInteger current;

        Console.WriteLine("0 \n1");
        for (int i = 3; i <= N; i++)
        {
            current = last + lastButOne;
            Console.WriteLine(current);
            lastButOne = last;
            last = current;
        }
    }
}
