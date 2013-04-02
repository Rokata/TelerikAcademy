using System;

class HexademicalToBinaryDirect
{
    static void Main()
    {
        Console.Write("Enter a number in hexademical numeral system: ");
        string hexNumber = Console.ReadLine();

        Console.WriteLine("Binary presentation: {0}", Convert.ToString(Convert.ToInt32(hexNumber,16), 2));
    }
}
