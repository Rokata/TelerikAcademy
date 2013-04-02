using System;

class DecimalToHexademical
{
    static void Main()
    {
        Console.Write("Enter decimal number: ");
        int decimalNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("Hexademical presentation: 0x" + Convert.ToString(decimalNumber, 16).ToUpper());
    }
}
