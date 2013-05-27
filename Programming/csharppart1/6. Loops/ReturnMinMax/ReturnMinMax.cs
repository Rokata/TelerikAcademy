using System;

class ReturnMinMax
{
    static void Main()
    {
        int N = 5;
        int min, max, num;

        Console.WriteLine("Input first number...");
        if (!int.TryParse(Console.ReadLine(), out num))
        {
            Console.WriteLine("Invalid input!");
            return;
        }
        min = max = num;

        for (int i = 1; i <= N - 1; i++)
        {
            Console.WriteLine("Input next number...");

            if (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            if (num > max) max = num;
            if (num < min) min = num;
        }

        Console.WriteLine("Min={0}, Max={1}", min, max);
    }
}
