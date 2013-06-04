using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class WordsCountInStr
{
    static void Main()
    {
        Console.Write("Enter string: ");
        string str = Console.ReadLine();

        Dictionary<string, int> words = new Dictionary<string, int>();

        foreach (Match match in Regex.Matches(str.ToLower(), @"\b\w+\b", RegexOptions.IgnoreCase))
            words[match.Value] = words.ContainsKey(match.Value) ? words[match.Value] + 1 : 1;
            
        foreach (KeyValuePair<string, int> couple in words)
            Console.WriteLine("{0} - {1}", couple.Key, couple.Value);
    }
}