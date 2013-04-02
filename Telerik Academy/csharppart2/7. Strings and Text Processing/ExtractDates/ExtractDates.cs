using System;
using System.Text.RegularExpressions;
using System.Globalization;

class Program
{
    static void Main()
    {
        string text = "some text with dates 01.09.2001 and even 08.3.2001 more dates 04.08.2009";
        DateTime date;

        foreach (Match match in Regex.Matches(text, @"\d{1,2}\.\d{1,2}\.\d{4}"))
        {
            if (DateTime.TryParseExact(match.Value, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                Console.WriteLine(date.ToString(CultureInfo.GetCultureInfo("en-CA").DateTimeFormat.ShortDatePattern));
        }
    }
}
