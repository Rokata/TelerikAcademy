using System;
using System.Collections.Generic;

namespace LinkedListImplementation
{
    class LinkedListTest
    {
        static void Main()
        {
            LinkedList<int> numbers = new LinkedList<int>();

            ListItem<int>[] elements = new ListItem<int>[] 
            {
                new ListItem<int> { Value = 10 },
                new ListItem<int> { Value = 54 },
                new ListItem<int> { Value = 33 },
                new ListItem<int> { Value = 23 },
                new ListItem<int> { Value = 11 },
                new ListItem<int> { Value = 182 },
                new ListItem<int> { Value = 73 }
            };

            foreach (ListItem<int> item in elements)
                numbers.Add(item);

            Console.WriteLine(numbers);
            numbers.Reverse();
            Console.WriteLine(numbers);
        }
    }
}
