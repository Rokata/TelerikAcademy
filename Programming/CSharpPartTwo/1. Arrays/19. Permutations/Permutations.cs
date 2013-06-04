using System;

class Program
{
    public static bool NextPermutation(int[] currentPermutation)
    {
        int length = currentPermutation.Length;
        int indexOfLastLower = -1;

        // check the index of the first element lower than its next neighbour
        for (int i = 1; i < length; i++)
        {
            if (currentPermutation[i - 1] < currentPermutation[i])
                indexOfLastLower = i - 1; 
        }
            
        // if it's -1 all permutations were generated and the initial sequence of the array is restored
        if (indexOfLastLower == -1)
        {
            for (int i = 0; i < length; i++)
                currentPermutation[i] = i;
            return false;
        }

        int changeIndex = indexOfLastLower + 1;
        for (int i = changeIndex; i < length; i++)
        {
            if (currentPermutation[indexOfLastLower] < currentPermutation[i])
                changeIndex = i; 
        }
            
        int temp = currentPermutation[indexOfLastLower];
        currentPermutation[indexOfLastLower] = currentPermutation[changeIndex];
        currentPermutation[changeIndex] = temp;

        Array.Reverse(currentPermutation, indexOfLastLower + 1, currentPermutation.Length - (indexOfLastLower + 1));
        
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
