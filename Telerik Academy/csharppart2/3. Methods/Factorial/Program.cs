using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class Program
{
    public static BigInteger Factorial(int number)
    {
        BigInteger result = 1;

        for (int i = 1; i <= number; i++) result *= i;

        return result;
    }

    static void Main()
    {
        for (int i = 1; i <= 100; i++)
        {
            Console.WriteLine("Factorial of {0}: {1}", i, Factorial(i));
        }
    }
}
