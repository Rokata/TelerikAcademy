using System;
using System.Text;

class Encrypt
{
    static void Main()
    {
        string str = "some random string";
        string cipher = "DS@732&SW";
        StringBuilder encoded = new StringBuilder();
        int cipherIndex = 0;

        for (int i = 0; i < str.Length; i++)
        {
            encoded.Append((char)(str[i] ^ cipher[cipherIndex]));
            cipherIndex++;

            if (cipherIndex == cipher.Length) cipherIndex = 0;
        }

        Console.WriteLine("Encoded string: " + encoded.ToString());
        Console.Write("Decoded string: ");

        for (int i = 0; i < encoded.Length; i++)
        {
            Console.Write((char)(encoded[i] ^ cipher[cipherIndex]));
            cipherIndex++;

            if (cipherIndex == cipher.Length) cipherIndex = 0;
        }

        Console.WriteLine();
    }

}