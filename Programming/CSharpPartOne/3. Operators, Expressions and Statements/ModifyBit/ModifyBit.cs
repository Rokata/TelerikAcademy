using System;

class ModifyBit
{
    static void Main()
    {
        Console.Write("Enter number: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter position p: ");
        int p = int.Parse(Console.ReadLine());
        Console.Write("Enter value (0 or 1): ");
        int v = int.Parse(Console.ReadLine());

        n = (v == 1) ? (n | (1 << p)) : (n & ~(1 << p));

        Console.WriteLine("Modified n: " + Convert.ToString(n, 2).PadLeft(16, '0'));
    }
}
