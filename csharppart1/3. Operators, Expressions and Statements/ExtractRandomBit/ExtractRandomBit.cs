using System;

class ExtractRandomBit
{
    static void Main()
    {
        Console.Write("Enter number: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Enter number of bit to extract: ");
        int bit = int.Parse(Console.ReadLine());

        int value = (n & (1 << bit)) >> bit;

        Console.WriteLine("Bit No.{0} of {1} is {2}", bit, n, value);
    }
}
