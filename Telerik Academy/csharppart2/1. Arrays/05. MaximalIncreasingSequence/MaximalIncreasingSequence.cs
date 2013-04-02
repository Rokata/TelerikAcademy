using System;
using System.Collections.Generic;
using System.Text;


class Program
{
    static void Main()
    {
        int[] array = { 5, 8, 11, 5, 9, 12, 16, 18, 25, 3, 4, 5, 11, 9, 5, 8, 10, 11 };
        int maxSequenceCount = 0;
        List<int> currentSequence = new List<int>();
        List<int> maxSequence = new List<int>();
        currentSequence.Add(array[0]);

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > array[i - 1])
            {
                currentSequence.Add(array[i]);
            }
            else
            {
                if (currentSequence.Count > maxSequenceCount)
                {
                    maxSequenceCount = currentSequence.Count;
                    maxSequence.Clear();
                    maxSequence.AddRange(currentSequence);
                }

                currentSequence.Clear();
                currentSequence.Add(array[i]);
            }
        }

        Console.Write("Max increasing result: ");

        StringBuilder result = new StringBuilder();
        result.Append("{");

        foreach (int item in maxSequence) result.Append(item + ", ");

        result.Remove(result.Length - 2, 2);
        result.Append("}");

        Console.WriteLine(result);
    }
}
