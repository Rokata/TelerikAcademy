using GenericList;
using System;
using System.Collections.Generic;

class GenericListDemo
{
    static void Main()
    {
        try
        {
            GenericList<int> list = new GenericList<int>(2);
            list.Add(10);
            list.Add(5);
            list.Add(4);
            list.Add(34);
            list.Add(124);
            list.Add(488);

            Console.WriteLine("Initial list: " + list.ToString());
            Console.WriteLine("Min: " + list.Min());
            Console.WriteLine("Max: " + list.Max());

            list.RemoveAt(3);

            Console.WriteLine("After removing list[3]: " + list.ToString());

            list.Add(88);

            Console.WriteLine("After adding 88: " + list.ToString());

            list.InsertAt(1, 911);

            Console.WriteLine("After inserting 911 at index 1: " + list.ToString());
            Console.WriteLine("List[4]: " + list[4]);

            list.Clear();
            Console.WriteLine("After clearing list: " + list.ToString());

            list.Add(4);
            list.Add(11);
            list.Add(19);
            Console.WriteLine("New list: " + list.ToString());

            list.RemoveAt(2);
            Console.WriteLine("After removing last element: " + list.ToString());

            Console.WriteLine("List capacity now: " + list.Capacity);
            Console.WriteLine("List size now: " + list.Count);
        }
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
