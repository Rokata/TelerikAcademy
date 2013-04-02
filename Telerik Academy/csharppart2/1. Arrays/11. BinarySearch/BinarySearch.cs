using System;

class Program
{
    public const int NOT_FOUND = -1;

    static void Main()
    {
        int[] numbers = { 3, 4, 6, 11, 32, 45, 65, 72, 82, 98, 104, 199 };
        int key = 45;
        int min = 0, max = numbers.Length - 1, mid, index = NOT_FOUND;

        while (max >= min)
        {
            mid = (min + max) / 2;

            if (key > numbers[mid])
                min = mid + 1;
            else if (key < numbers[mid])
                max = mid - 1;
            else
            {
                index = mid;
                break;             
            }
        }

        if (index == NOT_FOUND) Console.WriteLine("Element not found!");
        else Console.WriteLine("Index of element in the array: " + index);
    }
}


