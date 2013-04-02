using System;

class ShortBinary
{
    static short maxVal = 32767;

    static void Main()
    {
        Console.Write("Enter short [-32768; 32767]: ");
        short s = short.Parse(Console.ReadLine());

        if (s >= 0)
        {
            Console.WriteLine(Convert.ToString(s, 2));
        }
        else
        {
            short binaryPart = (short)(maxVal + 1 + s);
            Console.WriteLine("1" + Convert.ToString(binaryPart, 2));
        } 
    }
}
