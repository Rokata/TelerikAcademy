using System;
using System.Collections.Generic;
using System.Text;

class MaximalSequenceSum
{
    static void Main()
    {
        int[] a = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
        List<int> maxSubSequence = new List<int>();
        List<int> subSequence = new List<int>();

        int currentSum = 0;
        int biggestSum = 0;

        for (int i = 0; i < a.Length; ++i)
        {
            subSequence.Add(a[i]);
            currentSum += a[i];

            if (currentSum > biggestSum)
            {
                biggestSum = currentSum;
                maxSubSequence.Clear();
                maxSubSequence.AddRange(subSequence);
            }

            else if (currentSum < 0)
            {
                currentSum = 0;
                subSequence.Clear();
            }
        }

        StringBuilder result = new StringBuilder();
        result.Append("{");

        foreach (int i in maxSubSequence) result.Append(i + ", ");

        result.Remove(result.Length - 2, 2);
        result.Append("}");

        Console.WriteLine("{0} (Sum: {1})", result, biggestSum);
    }
}
