using System;
using System.Globalization;

namespace DefiningExceptionClass
{
    class ExceptionsDemo
    {
        static void Main()
        {
            try
            {
                Console.Write("Enter number between 0 and 100: ");
                int number = int.Parse(Console.ReadLine());

                if (number < 0 || number > 100)
                {
                    throw new InvalidRangeException<int>(1, 100);
                }

                Console.Write("Enter date in the range [1.1.1980 … 31.12.2013]: ");
                DateTime date = DateTime.ParseExact(Console.ReadLine(), "d.MM.yyyy", CultureInfo.InvariantCulture);

                if (date.Year < 1980 || date.Year > 2013)
                {
                    throw new InvalidRangeException<DateTime>(new DateTime(1980, 1, 1), new DateTime(2013, 12, 31));
                }

                Console.WriteLine("Number: {0}", number);
                Console.WriteLine("Date: {0}", date);
            }
            catch (InvalidRangeException<int> e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidRangeException<DateTime> e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
