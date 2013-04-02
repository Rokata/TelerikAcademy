using System;

class EucledianAlgorithm
{
    public static int GCD_Recursive(int a, int b)
    {
        if (b == 0)
            return a;
        else
            return GCD_Recursive(b, a % b);
    }

    static void Main(string[] args)
    {
        int a = 731, b = 544;
        Console.WriteLine("Greatest common divisor of {0} and {1} is {2}", a, b, GCD_Recursive(a, b));
    }
}
