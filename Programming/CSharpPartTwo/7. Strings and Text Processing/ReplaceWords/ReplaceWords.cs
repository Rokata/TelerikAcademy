﻿using System;
using System.Text;
using System.Text.RegularExpressions;

class ReplaceWords
{
    static void Main()
    {
        string message = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        string words = "PHP, CLR, Microsoft";

        Console.WriteLine(Regex.Replace(message, @"\b" + words.Replace(", ", "|") + @"\b", m => new String('*', m.Length)));
    }

}
