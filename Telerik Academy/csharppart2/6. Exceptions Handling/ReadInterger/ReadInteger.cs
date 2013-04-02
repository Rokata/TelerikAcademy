using System;

class ReadInteger
{
    static void Main()
    {
        try
        {
            int number;
            Console.Write("Enter positive integer: ");

            if (!int.TryParse(Console.ReadLine(), out number) || number < 0)
            {
                throw new ArgumentException();
            }

            Console.WriteLine("Square root of {0}: {1}", number, Math.Round(Math.Sqrt(number), 5));
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("Invalid number");
        }
        finally {
            Console.WriteLine("Good bye");
        }
    }
}
