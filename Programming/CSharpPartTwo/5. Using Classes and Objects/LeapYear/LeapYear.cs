using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter year: ");
        int year = int.Parse(Console.ReadLine());

        Console.WriteLine(DateTime.IsLeapYear(year) ? "leap" : "not leap");
    }
}
