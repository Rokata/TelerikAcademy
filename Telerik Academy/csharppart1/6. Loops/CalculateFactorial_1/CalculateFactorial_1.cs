using System;

class CalculateFactorial_1
{
    static void Main()
    {
        int N = 5, K = 8;
        int factN = 1, factK = 1;

        for (int i = 1; i <= N; i++) factN *= i;
        for (int i = 1; i <= K; i++) factK *= i;

        Console.WriteLine("N!/K!={0}", (double)factN / factK);
    }
}
