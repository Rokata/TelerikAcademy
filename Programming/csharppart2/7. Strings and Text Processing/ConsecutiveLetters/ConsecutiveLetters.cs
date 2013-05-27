using System;
using System.Text.RegularExpressions;

class ConsecutiveLetters
{
    static void Main()
    {
        string str = "zaaaaabbbbbcdddeeeedssazsxb";

        Console.WriteLine(Regex.Replace(str, @"(\w)\1+", "$1"));
        //StringBuilder result = new StringBuilder();

        //for (int i = 1; i < str.Length; i++)
        //{
        //    while (i < str.Length && str[i] == str[i - 1]) i++;
        //    result.Append(str[i - 1]);
        //}
        //if (str[str.Length-1] != str[str.Length-2]) result.Append(str[str.Length-1]);
        //str = result.ToString();
        //Console.WriteLine(str);
    }
}
