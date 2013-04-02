using System;

class Program
{
    public static int CalculateWorkdays(DateTime date, DateTime[] holidays)
    {
        int workdays = 0;
        DateTime tempDate = DateTime.Today;

        do
        {
            bool isHoliday = false;
            foreach (DateTime d in holidays)
            {
                if (d.Date == tempDate.Date)
                {
                    isHoliday = true;
                    break;
                }
            }
            if (isHoliday)
            {
                tempDate = tempDate.AddDays(1);
                continue;
            }

            if (tempDate.DayOfWeek != DayOfWeek.Saturday && tempDate.DayOfWeek != DayOfWeek.Sunday) workdays++;

            tempDate = tempDate.AddDays(1);
        } while (tempDate.Date <= date.Date);

        return workdays;
    }

    static void Main()
    {
        DateTime[] holidays = {
                                new DateTime(2013, 1, 1),
                                new DateTime(2013, 3, 3),
                                new DateTime(2013, 5, 3),
                                new DateTime(2013, 5, 6),
                                new DateTime(2013, 5, 24),
                                new DateTime(2013, 9, 22),
                                new DateTime(2013, 12, 24),
                                new DateTime(2013, 12, 25),
                                new DateTime(2013, 12, 26),
                                new DateTime(2013, 12, 31)
                              };

        Console.WriteLine("Workdays between now and 15/05/2013: {0}", CalculateWorkdays(new DateTime(2013, 5, 18), holidays));
    }
}
