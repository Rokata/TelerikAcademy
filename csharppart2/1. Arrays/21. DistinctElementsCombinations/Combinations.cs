using System;

class Combinations
{
    static int N, K;

    static void GenCombinations(int index, int[] vector, int start)
    {
        if (index == -1)
            Print(vector);
        else
        {
            for (int i = start; i <= N; i++)
            {
                vector[index] = i;
                GenCombinations(index - 1, vector, i+1);
            }
        }
    }

    static void Print(int[] vector)
    {
        for (int i = vector.Length-1; i >= 0; i--) Console.Write(vector[i] + " ");
        Console.WriteLine();
    }

    static void Main()
    {
        Console.Write("N = ");
        N = int.Parse(Console.ReadLine());
        Console.Write("K = ");
        K = int.Parse(Console.ReadLine());

        int[] vector = new int[K];

        GenCombinations(K-1, vector, 1);
    }
}