using System;
using System.Collections.Generic;

namespace RemoveNegatives
{
    class RemoveNegativesFromList
    {
        static List<int> InitSequence()
        {
            List<int> sequence = new List<int>();

            for (string input = Console.ReadLine(); input != ""; )
            {
                int number = int.Parse(input);
                sequence.Add(number);
                input = Console.ReadLine();
            }

            return sequence;
        }

        static void RemoveNegatives(List<int> list) 
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] < 0) list.RemoveAt(i);
            }
        }

        static void Main()
        {
            List<int> numbers = InitSequence();
            RemoveNegatives(numbers);

            Console.WriteLine("Sequence without negatives: {0}", string.Join(", ", numbers));
        }
    }
}
