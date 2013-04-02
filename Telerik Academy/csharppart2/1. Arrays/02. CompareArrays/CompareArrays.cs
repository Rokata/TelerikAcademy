using System;

class CompareArrays
{
    static void Main()
    {
        Console.Write("First array length: ");
        int length1 = int.Parse(Console.ReadLine());
        Console.Write("Second array length: ");
        int length2 = int.Parse(Console.ReadLine());

        if (length1 != length2)
        {
            Console.WriteLine("Array 1 != Array 2");
            return;
        }

        int[] arr1 = new int[length1];
        int[] arr2 = new int[length2];

        Console.WriteLine("Elements of first array: ");
        for (int i = 0; i < length1; i++)
        {
            Console.Write("arr1[{0}] = ", i);
            arr1[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine();

        Console.WriteLine("Elements of second array: ");
        for (int i = 0; i < length1; i++)
        {
            Console.Write("arr1[{0}] = ", i);
            arr2[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine();

        for (int i = 0; i < length1; i++)
        {
            if (arr1[i] != arr2[i])
            {
                Console.WriteLine("Array 1 != Array 2");
                return;
            }
        }

        Console.WriteLine("Array 1 = Array 2");
    }
}
