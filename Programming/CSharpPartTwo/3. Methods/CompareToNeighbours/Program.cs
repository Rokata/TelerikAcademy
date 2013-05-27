using System;

class Program
{
    public static bool CompareToNeighbours(int[] numbersArray, int position)
    {
        if (position >= numbersArray.Length - 1 || position <= 0) return false;

        if (numbersArray[position] > numbersArray[position - 1] && numbersArray[position] > numbersArray[position + 1])
        {
            return true;
        }
        else return false;
    }

    static void Main()
    {
        int[] numbers = { 5, 11, 7, 3, 5, 9, 5, 7, 8, 9, 3, 4, 1, 10, 75, 34, 99, 11, 18, 43 };

        int position = int.Parse(Console.ReadLine());
        Console.WriteLine("Element is bigger: " + CompareToNeighbours(numbers, position));
    }
}
