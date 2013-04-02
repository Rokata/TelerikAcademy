using System;

class SumOfSubsets
{
    static void Main()
    {
        int a = 3, b = -2, c = -1, d = 1, e = 8;

        if (a + b + c == 0 || a + b + d == 0 || a + b + e == 0 || a + c + d == 0 || a + c + e == 0 || a + d + e == 0 ||
            b + c + d == 0 || b + c + e == 0 || b + d + e == 0 || c + d + e == 0)
        {
            Console.WriteLine("There is a subset with sum = 0");
        }
        else
        {
            Console.WriteLine("No such subset");
        }
    }
}
