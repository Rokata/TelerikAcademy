using System;

class ExchangeBits
{
    static void Main()
    {
        Console.Write("Enter number: ");
        uint n = uint.Parse(Console.ReadLine());
        Console.WriteLine("n before: " + Convert.ToString(n, 2).PadLeft(32, '0'));

        byte thirdBit = (byte)(((1 << 3) & n) >> 3);
        byte forthBit = (byte)(((1 << 4) & n) >> 4);
        byte fifthBit = (byte)(((1 << 5) & n) >> 5);
        byte bit24 = (byte)(((1 << 24) & n) >> 24);
        byte bit25 = (byte)(((1 << 25) & n) >> 25);
        byte bit26 = (byte)(((1 << 26) & n) >> 26);

        n = (uint)((bit24 == 1) ? (n | (1 << 3)) : (n & ~(1 << 3)));
        n = (uint)((bit25 == 1) ? (n | (1 << 4)) : (n & ~(1 << 4)));
        n = (uint)((bit26 == 1) ? (n | (1 << 5)) : (n & ~(1 << 5)));
        n = (uint)((thirdBit == 1) ? (n | (1 << 24)) : (n & ~(1 << 24)));
        n = (uint)((forthBit == 1) ? (n | (1 << 25)) : (n & ~(1 << 25)));
        n = (uint)((fifthBit == 1) ? (n | (1 << 26)) : (n & ~(1 << 26)));

        Console.WriteLine("n after:  " + Convert.ToString(n, 2).PadLeft(32, '0'));
    }
}
