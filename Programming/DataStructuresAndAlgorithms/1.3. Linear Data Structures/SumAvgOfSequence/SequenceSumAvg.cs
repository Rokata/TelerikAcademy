using System;
using System.Linq;
using System.Collections.Generic;

namespace SumAvgOfSequence
{
    class SequenceSumAvg
    {
        static List<uint> InitSequence()
        {
            List<uint> sequence = new List<uint>();

            for (string input = Console.ReadLine(); input != ""; input = Console.ReadLine())
            {
                uint number = uint.Parse(input);
                sequence.Add(number);
            }

            return sequence;
        }

        static void Main()
        {
            List<uint> numbers = InitSequence();

            Console.WriteLine("Sum of sequence: {0}", numbers.Sum(x => x));
            Console.WriteLine("Average of sequence: {0}", numbers.Average(x => x));
        }
    }
}
