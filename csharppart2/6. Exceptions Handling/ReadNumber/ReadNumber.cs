using System;

class ReadNumber_
{
    public static int ReadNumber(int start, int end)
    {
        int number;

        if (!int.TryParse(Console.ReadLine(), out number) || number <= start || number >= end) {
            throw new ArgumentException();
        }

        return number;
    }

    static void Main()
    {
        try
        {
            Console.Write("Enter next integer: ");
            int prev = ReadNumber(1, 100);

            for (int i = 1; i < 10; i++)
            {
                Console.Write("Enter next integer: ");
                prev = ReadNumber(prev, 100);
            }
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("Invalid number!");
        }
    }
}
