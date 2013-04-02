using System;

class SortWordsList
{
    static void Main()
    {
        string[] words = Console.ReadLine().Split(' ');
        Array.Sort(words);
        foreach (string word in words) Console.WriteLine(word);
    }
}
