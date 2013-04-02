using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    public static int MaxOfPortion(int[] array, int index)
    {
        if (index < 0 || index > array.Length - 1) return -1;

        int max = array[index];
        int maxIndex = index;

        for (int i = index+1; i < array.Length; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
                maxIndex = i;
            }
        }
        array[maxIndex] = int.MinValue;

        return max;
    }

    public static int[] DescendingSort(int[] array)
    {
        int[] sorted = new int[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            sorted[i] = MaxOfPortion(array, 0);
        }

        return sorted;
    }

    public static int[] AscendingSort(int[] array)
    {
        int[] sorted = new int[array.Length];

        for (int i = array.Length-1; i >= 0; i--)
        {
            sorted[i] = MaxOfPortion(array, 0);
        }

        return sorted;
    }

    static void Main()
    {
        int[] arrayOne = { 5, 1, 2, 3, 5, 9, 5, 7, 8, 9, 3, 4, 1, 10, 75, 34, 99, 11, 18, 43 };
        int[] arrayTwo = { 6, 1, 9, 6, 104, 74, 11, 54, 34, 9, 10, 65 };

        int[] sortedArray = DescendingSort(arrayOne);
        Console.Write("Array sorted in descending order: ");
        foreach (int num in sortedArray) Console.Write(num + " ");

        Console.WriteLine();

        sortedArray = AscendingSort(arrayTwo);
        Console.Write("Array sorted in ascending order: ");
        foreach (int num in sortedArray) Console.Write(num + " ");
        Console.WriteLine();
    }
}
