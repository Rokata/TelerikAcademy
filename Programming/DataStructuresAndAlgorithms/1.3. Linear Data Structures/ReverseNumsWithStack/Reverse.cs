using System;
using System.Collections.Generic;

namespace ReverseNumsWithStack
{
    class Reverse
    {
        static Stack<int> ReadInput(int length)
        {
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < length; i++)
            {
                Console.Write("Enter next element: ");
                int element = int.Parse(Console.ReadLine());
                stack.Push(element);
            }

            return stack;
        }

        static void PrintStack(Stack<int> stack)
        {
            Console.Write("Order reversed: ");

            while (stack.Count > 0)
                Console.Write(stack.Pop() + " ");

            Console.WriteLine();
        }

        static void Main()
        {
            Console.Write("Enter sequence length: ");
            int length = int.Parse(Console.ReadLine());

            Stack<int> numbers = ReadInput(length);
            PrintStack(numbers);
        }
    }
}
