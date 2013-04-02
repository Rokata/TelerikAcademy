using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("N=? ");
        int N = int.Parse(Console.ReadLine());
        Console.Write("K=? ");
        int K = int.Parse(Console.ReadLine());

        int[] numbers = new int[N];

        for (int i = 0; i < N; i++)
        {
            Console.Write("numbers[{0}] = ", i);
            numbers[i] = int.Parse(Console.ReadLine());
        }
        Array.Sort(numbers);

        int index = Array.BinarySearch(numbers, K);

        if (K < numbers[0]) Console.WriteLine("No number in the array is less or equal to K.");
        else
        {
            Console.Write("Biggest number equal or less than K: ");

            if (index > 0) Console.WriteLine(numbers[index]);
            else Console.WriteLine(numbers[~index - 1]);
        }
    }
}
