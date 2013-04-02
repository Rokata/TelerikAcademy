using System;

class PrintAsciiTable
{
    static void Main()
    {
        for (int i = 0; i <= 127; i++) Console.Write((char)i + " ");
        Console.WriteLine();
    }
}
