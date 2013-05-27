using System;

class Program
{
    static void Main()
    {
        double S = 1;
        int N = 2, X = 2, factNum = 1, powX = 1;

        for (int i = 1; i <= N; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                factNum *= j;
                powX *= X;
            }
            S += (double)factNum / powX;
        }

        Console.WriteLine("Sum: {0}", S);
    }
}
