using System;

class CheckThirdBit
{
    static void Main()
    {
        Console.Write("Enter number: ");
        int i = int.Parse(Console.ReadLine()); ;
        int bit = i & (1 << 3);

        Console.WriteLine("Third bit is " + (bit >> 3));
    }
}
