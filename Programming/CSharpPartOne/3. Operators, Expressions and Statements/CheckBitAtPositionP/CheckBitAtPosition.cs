using System;

class CheckBitAtPosition
{
    static void Main()
    {
        Console.Write("Enter number: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Enter number of bit to check: ");
        int bit = int.Parse(Console.ReadLine());

        Console.WriteLine("Bit No.{0} is 1: {1}", bit, ((n & (1 << bit)) >> bit) == 1 ? true : false);
    }
}
