using System;
using System.Text.RegularExpressions;

class CountSubstring
{
    static void Main()
    {
        string text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        int count = 0;
        int index = 0;

        while ((index = text.IndexOf("in", index, StringComparison.OrdinalIgnoreCase)) != -1)
        {
            count++;
            index += 2;
        }

        Console.WriteLine("Matches: " + count);
    }
}
