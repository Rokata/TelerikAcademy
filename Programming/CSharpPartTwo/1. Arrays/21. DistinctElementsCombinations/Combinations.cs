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
                GenCombinations(index - 1, vector, i+1); // i+1 to make sure there are no repetitions
            }
        }
    }

    static void Print(int[] vector)
    {
        for (int i = vector.Length-1; i >= 0; i--) 
            Console.Write(vector[i] + " ");
        Console.WriteLine();
    }

    static void Main()
    {
        Console.Write("N = ");
        N = int.Parse(Console.ReadLine());
        Console.Write("K = ");
        K = int.Parse(Console.ReadLine());

        /* vector is exact K elements long, in other tasks
         * it is needed to generate all possible combinations with different length 
         * and vector's length can be from 1 to the size of numbers or other data array */
        int[] vector = new int[K]; 

        /* here start parameter is 1 as there is no array of data with indexes and only numbers */
        GenCombinations(K-1, vector, 1);
    }
}