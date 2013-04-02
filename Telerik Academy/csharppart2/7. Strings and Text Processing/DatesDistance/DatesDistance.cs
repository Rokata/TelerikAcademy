using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class DatesDistance
{
    static void Main()
    {
        try
        {
            Console.Write("Enter first date: ");
            string firstDate = Console.ReadLine();
            Console.Write("Enter second date: ");
            string secondDate = Console.ReadLine();

            string[] dmy1 = firstDate.Split('.');
            string[] dmy2 = secondDate.Split('.');

            DateTime date1 = new DateTime(int.Parse(dmy1[2]), int.Parse(dmy1[1]), int.Parse(dmy1[0]));
            DateTime date2 = new DateTime(int.Parse(dmy2[2]), int.Parse(dmy2[1]), int.Parse(dmy2[0]));
            TimeSpan span = date2 - date1;
  
            if (span.TotalDays < 0) Console.WriteLine("There are {0} days between the thow dates", span.TotalDays * -1);
            else Console.WriteLine("There are {0} days between the thow dates", span.TotalDays);
        }

        catch (Exception)
        {
            Console.WriteLine("Invalid date format!");
        }
    }
}
