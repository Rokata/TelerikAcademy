using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoveOddCounted
{
    class RemoveOdd
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

        static Dictionary<int, int> CreateCountDictionary(List<int> numbers)
        {
            Dictionary<int, int> countDictionary = new Dictionary<int, int>();

            foreach (int item in numbers)
            {
                if (countDictionary.ContainsKey(item))
                    countDictionary[item]++;
                else
                    countDictionary.Add(item, 1);
            }

            return countDictionary;
        }

        static List<int> GetOddCountedList(Dictionary<int, int> counts)
        {
            List<int> oddCounted = new List<int>();

            foreach (KeyValuePair<int, int> entry in counts)
            {
                if (entry.Value % 2 != 0)
                    oddCounted.Add(entry.Key);
            }

            return oddCounted;
        }

        static void RemoveOddCounted(List<int> numbersList, List<int> oddCounted)
        {
            foreach (int item in oddCounted)
                numbersList.RemoveAll(x => x == item);
        }

        static void Main()
        {
            List<int> numbers = InitSequence();
            List<int> oddCounted = GetOddCountedList(CreateCountDictionary(numbers));
            RemoveOddCounted(numbers, oddCounted);

            Console.WriteLine("List without odd counted: {0}", string.Join(", ", numbers));
        }
    }
}
