using System;
using System.Text;

class SelectionSort
{
    static void Main()
    {
        int[] numbers = { 5, 11, 6, 92, 73, 67, 104, 98, 97, 104, 11, 102, 8 };

        for (int i = 0; i < numbers.Length - 1; i++)
        {
            int min = i;

            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[j] < numbers[min]) min = j;
            }

            int temp = numbers[i];
            numbers[i] = numbers[min];
            numbers[min] = temp;
        }

        StringBuilder result = new StringBuilder();
        result.Append("{");

        foreach (int item in numbers) result.Append(item + ", ");

        result.Remove(result.Length-2, 2);
        result.Append("}");

        Console.WriteLine(result);
    }
}
