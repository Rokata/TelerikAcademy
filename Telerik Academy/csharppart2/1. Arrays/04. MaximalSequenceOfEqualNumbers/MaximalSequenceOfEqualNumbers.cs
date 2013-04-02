using System;

namespace _04.MaximalSequenceOfEqualNumbers
{
    class MaximalSequenceOfEqualNumbers
    {
        static void Main()
        {
            int[] numbers = { 5, 3, 3, 3, 3, 4, 7, 9, 9, 9, 8, 9, 9, 11, 15, 11, 11, 11, 6, 15, 10, 10, 8 };
            int currentSequenceCount = 1;
            int maxSequenceCount = 1;
            int maxSequentialNumber = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] == numbers[i - 1]) currentSequenceCount++;
                else
                {
                    if (currentSequenceCount > maxSequenceCount)
                    {
                        maxSequenceCount = currentSequenceCount;
                        maxSequentialNumber = numbers[i - 1];
                    }
                    currentSequenceCount = 1;                    
                }
            }

            Console.Write("Max sequence: {");
            for (int i = 0; i < maxSequenceCount; i++)
            {
                if (i == maxSequenceCount - 1) Console.Write(maxSequentialNumber + "}\n");
                else Console.Write(maxSequentialNumber + ", ");
            }
        }
    }
}
