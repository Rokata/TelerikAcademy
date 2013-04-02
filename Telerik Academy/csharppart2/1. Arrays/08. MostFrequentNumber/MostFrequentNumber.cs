using System;
using System.Collections.Generic;

class MostFrequentNumber
{
    static void Main()
    {
        int[] numbers = { 111, 9, 4, 1, 9, 1, 4, 9, 2, 3, 4, 9, 4, 1, 2, 4, 9, 3 };
        int mostFrequent = 0;
        int times = 0;

        IDictionary<int, int> numberFrequency = new Dictionary<int, int>();

        foreach (int number in numbers)
        {
            if (!numberFrequency.ContainsKey(number))
            {
                numberFrequency.Add(number, 1);
            }
            else
            {
                ++numberFrequency[number];
            }
        }

        foreach (KeyValuePair<int, int> pair in numberFrequency)
        {
            if (pair.Value > times)
            {
                times = pair.Value;
                mostFrequent = pair.Key;
            }
        }

        Console.WriteLine("{0} ({1} times)", mostFrequent, times);
    }
}