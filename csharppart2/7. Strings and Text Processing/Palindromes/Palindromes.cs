using System;
using System.Text.RegularExpressions;

class Palindromes
{
    static void Main()
    {
        string text = "static void () System lamal saas xxaj exe";
        bool isPalindrome = true;

        Console.Write("Palindromes found: ");
        foreach (Match match in Regex.Matches(text, @"\b[A-Za-z]+\b"))
        {
            for (int i = 0; i < match.Value.Length / 2; i++)
            {
                if (match.Value[i] != match.Value[match.Value.Length - 1 - i])
                {
                    isPalindrome = false;
                    break;
                }
            }
            if (isPalindrome) Console.Write(match.Value + " ");
            isPalindrome = true;
        }
        Console.WriteLine();
    }
}
