using System;
using System.Collections.Generic;
using System.Linq;

namespace SortListAscending
{
    class SortList
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

        static void Main()
        {
            List<int> numbers = InitSequence();

            numbers.Sort();

            Console.WriteLine("Sequence sorted: {0}", string.Join(", ", numbers));
        }
    }
}
