using System;
using System.Collections.Generic;
using System.Text;

class EratosthenesSieve
{
    static void Main()
    {
        Console.Write("Enter N: ");
        int N = int.Parse(Console.ReadLine());
        bool[] A = new bool[N+2];

        for (int i = 2; i <= N; i++) A[i] = true;

        for (int i = 2; i <= Math.Sqrt(N); i++)
        {
            if (A[i] == true)
            {
                for (int j = 2*i; j <= N; j += i)
                {
                    A[j] = false;
                }
            }
        }

        StringBuilder result = new StringBuilder();
        result.Append("{");

        for (int i = 2; i <= N; i++)
        {
            if (A[i] == true) result.Append(i + ", ");
        }

        result.Remove(result.Length - 2, 2);
        result.Append("}");

        Console.WriteLine(result);
    }
}
