using System;
using System.Collections.Generic;

namespace SequenceWithQueue
{
    class SequenceWithQueue
    {
        static void PrintSequenceMembers(int count, int start)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);

            for (int i = 0; i < count; i++)
            {
                int element = queue.Dequeue();
                Console.Write(element + " ");

                queue.Enqueue(element + 1);
                queue.Enqueue(2 * element + 1);
                queue.Enqueue(element + 2);
            }
        }

        static void Main()
        {
            int count = 50;
            int start = 2;

            PrintSequenceMembers(count, start);
        }
    }
}
