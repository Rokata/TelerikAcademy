using System;

class Program
{
    public static bool NextPermutation(int[] currentPermutation)
    {
        int n = currentPermutation.Length;
        int k = -1;
        for (int i = 1; i < n; i++)
            if (currentPermutation[i - 1] < currentPermutation[i])
                k = i - 1;
        if (k == -1)
        {
            for (int i = 0; i < n; i++)
                currentPermutation[i] = i;
            return false;
        }

        int l = k + 1;
        for (int i = l; i < n; i++)
            if (currentPermutation[k] < currentPermutation[i])
                l = i;

        int t = currentPermutation[k];
        currentPermutation[k] = currentPermutation[l];
        currentPermutation[l] = t;

        Array.Reverse(currentPermutation, k + 1, currentPermutation.Length - (k + 1));
        
        return true;
    }

    static void Main(string[] args)
    {
        Console.Write("N = ");
        int size = int.Parse(Console.ReadLine());

        int[] arr = new int[size];

        for (int i = 0; i < arr.Length; i++) arr[i] = i + 1;

        foreach (int num in arr) Console.Write(num + " ");
        Console.WriteLine();

        while (NextPermutation(arr))
        {
            foreach (int num in arr) Console.Write(num + " ");
            Console.WriteLine();
        }
    }
}
