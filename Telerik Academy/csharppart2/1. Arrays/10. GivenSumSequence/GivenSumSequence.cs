using System;
using System.Collections.Generic;
using System.Text;

class GivenSumSequence
{
    static void Main()
    {
        int[] a = { 4, 3, 1, 4, 2, 5, 8 };
        int S = 15;
        int currentSum = 0;
        bool isFound = false;
        List<int> currentSequence = new List<int>();
        int startingIndex = 0;

        for (int i = 0; i < a.Length; ++i)
        {
            currentSequence.Add(a[i]);
            currentSum += a[i];

            if (currentSum > S)
            {
                currentSum = 0;
                currentSequence.Clear();
                i = startingIndex;
                startingIndex++;                
            }
            else if (currentSum == S)
            {
                isFound = true;
                break;
            }
        }

        if (currentSequence.Count > 0 && isFound)
        {
            StringBuilder result = new StringBuilder();
            result.Append("{");

            foreach (int i in currentSequence) result.Append(i + ", ");

            result.Remove(result.Length - 2, 2);
            result.Append("}");

            Console.WriteLine(result);
        }
        else Console.WriteLine("No such sequence with that sum!");
    }
}