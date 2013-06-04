using System;
using System.Text.RegularExpressions;

class Emails
{
    static void Main()
    {
        string text = "Static void Main() nakov@telerik.com. using System,nakov@gmail.com return";

        foreach (Match match in Regex.Matches(text, @"[\w_]+\@\w+\.[\w\.]+\w")) 
            Console.WriteLine(match.Value); 
    }
}
