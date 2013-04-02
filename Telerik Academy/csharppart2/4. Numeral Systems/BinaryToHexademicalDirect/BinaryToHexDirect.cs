using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number in binary numeral system: ");
        string binaryNumber = Console.ReadLine();

        Console.WriteLine("Hexademical presentation: {0}", Convert.ToString(Convert.ToInt32(binaryNumber, 2), 16));
    }
}
