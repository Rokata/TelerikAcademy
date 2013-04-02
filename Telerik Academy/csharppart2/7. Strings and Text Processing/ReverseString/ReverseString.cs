using System;

class ReverseString
{
    static void Main()
    {
        Console.Write("Enter input string: ");
        char[] input = Console.ReadLine().ToCharArray();

        Array.Reverse(input);

        Console.Write("String reversed: ");
        foreach (char character in input) Console.Write(character);

        Console.WriteLine();
    }
}
