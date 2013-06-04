using System;
using System.Globalization;

class AddHoursToDate
{
    static void Main()
    {
        Console.Write("Enter date: ");
        string strDate = Console.ReadLine();

        DateTime date = DateTime.ParseExact(strDate, "d.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);

        DateTime newDate = date.AddHours(6.5);

        Console.WriteLine("Date after 6 hrs 30 mins: {1} {0:d.MM.yyyy HH:mm:ss}", newDate, newDate.DayOfWeek);
    }
}
