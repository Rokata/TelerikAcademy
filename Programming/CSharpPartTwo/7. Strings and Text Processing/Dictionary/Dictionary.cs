using System;
using System.Text.RegularExpressions;

class Dictionary
{
    static void Main()
    {
        string[] dictionary = { 
            ".NET - platform for applications from Microsoft",
            "CLR - managed execution environment for .NET", 
            "namespace - hierarchical organization of classes"
        };

        Console.Write("Enter word: ");
        string search = Console.ReadLine();

        foreach (string def in dictionary)
        {
            var groups = Regex.Match(def, "(" + search + ") - (.*)").Groups;

            if (groups[1].Value == search) Console.WriteLine(groups[2].Value);
        }
    }
}
