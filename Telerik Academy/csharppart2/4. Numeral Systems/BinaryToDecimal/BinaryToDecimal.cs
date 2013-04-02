using System;

class BinaryToDecimal
{
    static void Main()
    {
        Console.Write("Enter a number in binary numeral system: ");
        char[] binaryArray = Console.ReadLine().ToCharArray();
        int dec = 0;

        Array.Reverse(binaryArray);

        for (int i = 0; i < binaryArray.Length; i++)
        {
            int bit = int.Parse(binaryArray[i].ToString());

            if (bit == 1)
            {
                for (int j = 0; j < i; j++)
                {
                    bit *= 2;
                }
            }

            dec += bit;
        }

        Console.WriteLine("Decimal presentation: " + dec);
    }
}
