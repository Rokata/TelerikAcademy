using System;

class ReverseWords
{
    static void Main()
    {
        string sentence = "C# is not C++, not PHP and not Delphi!";
        char mark = sentence[sentence.Length - 1];

        string[] words = sentence.Split(' ');
        int last = words.Length - 1;

        words[last] = words[last].Substring(0, words[last].Length - 1); // because of the mark

        for (int i = words.Length-1; i>=0; i--)
            Console.Write(words[i] + " ");
        Console.WriteLine("\b" + mark);
    }
}
