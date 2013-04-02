using System;

class SpecificSubset
{
    static int[] numbers;
    static int K, S;

    static void GenSubsetsOfKElements(int index, int[] vector, int start)
    {
        if (index == -1)
            CheckSum(vector);
        else
        {
            for (int i = start; i < numbers.Length; i++)
            {
                vector[index] = i;
                GenSubsetsOfKElements(index - 1, vector, i + 1);
            }
        }
    }

    static void CheckSum(int[] vector)
    {
        int sum = 0;

        foreach (int i in vector) sum += numbers[i];

        if (sum == S)
        {
            Console.Write("A subset with {0} elements of sum {1} exists: ", K, S);
            foreach (int i in vector) Console.Write(numbers[i] + " ");
            Console.WriteLine();

            Environment.Exit(0);
        }
    }

    static void Main()
    {
        Console.Write("N = ");
        int N = int.Parse(Console.ReadLine());
        Console.Write("K = ");
        K = int.Parse(Console.ReadLine());
        Console.Write("S = ");
        S = int.Parse(Console.ReadLine());

        numbers = new int[N];

        for (int i = 0; i < N; i++)
        {
            Console.Write("numbers[{0}]: ", i);
            numbers[i] = int.Parse(Console.ReadLine());
        }

        int[] vector = new int[K];

        GenSubsetsOfKElements(K-1, vector, 0);

        Console.WriteLine("No such subset found.");
    }
}
