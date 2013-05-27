using System;
using System.Collections.Generic;

class DifferentLetters
{
    static void Main(string[] args)
    {
        string str = "This is ejuh3u4h3 some crazy !&# string";
        Dictionary<char, int> letters = new Dictionary<char, int>();

        foreach (char ch in str.ToLower())
            if (Char.IsLetter(ch))
            {
                if (letters.ContainsKey(ch)) letters[ch]++;
                else letters.Add(ch, 1);
            }

        foreach (KeyValuePair<char, int> couple in letters)
            Console.WriteLine("{0} - {1}", couple.Key, couple.Value);
    }
}
