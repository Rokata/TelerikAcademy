using System;

class FindSubsetWithSum
{
    static int[] numbers = {5, 1, 2, 4, 8, 3, 7};
    static int S;

    static void GenSubsets(int index, int[] vector, int start)
    {
        if (index == -1)
            CheckSum(vector);
        else
        {
            for (int i = start; i < numbers.Length; i++)
            {
                vector[index] = i;
                GenSubsets(index - 1, vector, i + 1);
            }
        }
    }

    static void CheckSum(int[] vector)
    {        
        int sum = 0;

        foreach (int i in vector) sum += numbers[i];

        if (sum == S)
        {
            Console.WriteLine("A subset with sum {0} exists.", S);
            Environment.Exit(0);
        }
    }

    static void Main(string[] args)
    {
        int[] vector;
        Console.Write("S = ");
        S = int.Parse(Console.ReadLine());

        for (int i = 1; i <= numbers.Length; i++)
        {
            vector = new int[i];
            GenSubsets(vector.Length - 1, vector, 0);
        }

        Console.WriteLine("Subset with sum {0} not found.", S);
    }
}
