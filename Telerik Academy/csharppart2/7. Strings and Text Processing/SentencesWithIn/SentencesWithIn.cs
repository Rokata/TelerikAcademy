using System;
using System.Text.RegularExpressions;

class SentencesWithIn
{
    static void Main()
    {
        string text = "We are living in a yellow submarine. We don't have anything else. " +
        "Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";

        string[] sentences = text.Split('.');

        foreach (string sentence in sentences)
        {
            if (Regex.Matches(sentence, @"\b(in)\b", RegexOptions.IgnoreCase).Count > 0) 
                Console.WriteLine(sentence.Trim() + ".");
        }
    }
}