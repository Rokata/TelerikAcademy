using System;

class Spiral
{
    static void Main()
    {
        int N;
        Console.WriteLine("Enter N: ");
        if (!int.TryParse(Console.ReadLine(), out N)) {
            Console.WriteLine("Invalid input!"); return;
        }
        Console.WriteLine();

        int[,] mat = new int[N, N];
        int start = 0;
        int end = N;
        int k = 1;
        while (end - start >= 1)
        {
            for (int i = start; i < end; i++)
            {
                mat[start, i] = k;
                ++k;
            }
            for (int i = start + 1; i < end; i++)
            {
                mat[i, end - 1] = k;
                ++k;
            }
            for (int i = end - 2; i >= start; i--)
            {
                mat[end - 1, i] = k;
                ++k;
            }
            for (int i = end - 2; i >= start + 1; i--)
            {
                mat[i, start] = k;
                ++k;
            }
            ++start;
            --end;
        }

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write(mat[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}