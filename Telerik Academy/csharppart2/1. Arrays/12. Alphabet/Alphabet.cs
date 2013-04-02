using System;

class Program
{
    public const int MIN_ASCII_LOWER = 97;
    public const int MAX_ASCII_LOWER = 122;
    public const int MIN_ASCII_UPPER = 65;

    static void Main()
    {
        char[] alphabet = new char[26];
        int ascii_index = 65;

        for (int i = 0; i < alphabet.Length; i++, ascii_index++)
        {
            alphabet[i] = (char)ascii_index;
        }

        Console.Write("Enter word: ");
        string word = Console.ReadLine();

        foreach (char c in word)
        {
            int code = (int)c;

            if (c >= MIN_ASCII_LOWER && c <= MAX_ASCII_LOWER)
            {
                Console.WriteLine("Position of {0} in array: {1}", c, c - MIN_ASCII_LOWER);
            }
            else Console.WriteLine("Position of {0} in array: {1}", c, c - MIN_ASCII_UPPER);
        }
    }
}
