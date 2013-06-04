using System;
using System.Collections.Generic;

class FindAscSorted
{
    static int[] numbers = { 6, 1, 4, 3, 0, 3, 6, 4, 5 };
    static int elementsRemoved = int.MaxValue;
    static List<int> result = new List<int>();

    static void GenPossibleArrays(int index, int[] vector, int start)
    {
        if (index == -1)
            CheckAscendingSorted(vector);
        else
        {
            for (int i = start; i < numbers.Length; i++)
            {
                vector[index] = i;
                GenPossibleArrays(index - 1, vector, i + 1);
            }
        }
    } 

    static void CheckAscendingSorted(int[] vector)
    {
        // vector contains indexes of left elements - the other indexes are those of the removed elements
        int[] copyVector = (int[]) vector.Clone(); // clone because of reverse
        Array.Reverse(copyVector); 

        // check if resulting array is ascending sorted
        for (int i = 1; i < copyVector.Length; i++)
        {
            if (numbers[copyVector[i]] < numbers[copyVector[i - 1]]) return;
        }

        /* check if this is the best score - the minimum count of elements for removal
         * if so store the members of this combination 
         * */
        if (elementsRemoved > numbers.Length - copyVector.Length)
        {
            if (result.Count > 0) 
                result.Clear();
            
            elementsRemoved = numbers.Length - copyVector.Length;

            foreach (int item in copyVector) 
                result.Add(numbers[item]);
        }
    }

    static void Main()
    {
        int[] vector;

        for (int i = 1; i <= numbers.Length; i++)
        {
            vector = new int[i];
            GenPossibleArrays(vector.Length - 1, vector, 0);
        }

        Console.Write("Ascending sorted array: ");
        foreach (int i in result) Console.Write(i + " ");
        Console.WriteLine();
        Console.WriteLine("Elements removed: " + elementsRemoved);
    }
}
