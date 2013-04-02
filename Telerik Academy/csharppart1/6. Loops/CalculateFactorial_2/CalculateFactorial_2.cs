using System;

class CalculateFactorial_2
{
    static void Main()
    {
        int N = 5, K = 8, factN = 1, factK = 1, factKminN = 1;

        for (int i = 1; i <= N; i++) factN *= i;
        for (int i = 1; i <= K; i++) factN *= i;
        for (int i = 1; i <= K - N; i++) factKminN *= i;

        Console.WriteLine("N!*K!/(K-N)! = {0}", (double)(factN * factK) / factKminN);
    }
}
