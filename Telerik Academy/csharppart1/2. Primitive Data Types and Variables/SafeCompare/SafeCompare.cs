using System;

class SafeCompare
{
    static void Main()
    {
        float a = 6.00000092f;
        float b = 6.00000000092f;
        float precision = 0.000001f;

        bool compare = Math.Abs(a - b) < precision;

        Console.WriteLine(compare);
    }
}
