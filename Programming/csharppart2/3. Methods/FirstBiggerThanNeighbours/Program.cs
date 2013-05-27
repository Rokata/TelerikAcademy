using System;

class Program
{
    public static int IndexOfFirstBiggerThanNeighbours(int[] numbersArray)
    {
        for (int i = 1; i <= numbersArray.Length - 2; i++)
        {
            if (numbersArray[i] > numbersArray[i - 1] && numbersArray[i] > numbersArray[i + 1])
            {
                return i;
            }
        }
        return -1;
    }

    static void Main()
    {
        int[] numbers = { 5, 1, 2, 3, 5, 9, 5, 7, 8, 9, 3, 4, 1, 10, 75, 34, 99, 11, 18, 43 };

        Console.WriteLine("Index (-1 if not found): " + IndexOfFirstBiggerThanNeighbours(numbers));
    }
}
