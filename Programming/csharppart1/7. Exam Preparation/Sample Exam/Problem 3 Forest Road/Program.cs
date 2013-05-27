using System;

class Program
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (j == i) Console.Write("*");
                else Console.Write(".");
            }
            Console.WriteLine();
        }

        for (int i = N - 1; i > 0; i--)
        {
            for (int j = 0; j <= N - 1; j++)
            {
                if (j == i-1) Console.Write("*");
                else Console.Write(".");
            }
            Console.WriteLine();
        }
    }
}
