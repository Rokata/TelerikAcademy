using System;

class Program
{
    public static int GetNumberFrequency(int[] numbersArray, int target)
    {
        int count = 0;
        foreach (int i in numbersArray)
        {
            if (i == target) count++;
        }

        return count;
    }

    static void Main()
    {
        int[] numbers = { 5, 11, 7, 3, 5, 9, 5, 7, 8, 9, 3, 4, 1, 10, 75, 34, 99, 11, 18, 43 };
        int target = int.Parse(Console.ReadLine());

        Console.WriteLine("Number appears {0} time(s) in the array.", GetNumberFrequency(numbers, target));
    }
}
