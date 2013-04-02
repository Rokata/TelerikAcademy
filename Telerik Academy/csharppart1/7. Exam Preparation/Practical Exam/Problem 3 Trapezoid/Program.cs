using System;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        int points_left = N - 1;
        int points_right = N - 1;

        for (int i = 0; i < N; i++) Console.Write(".");
        for (int i = 0; i < N; i++) Console.Write("*");

        Console.WriteLine();

        for (int i = 0; i < N - 1 && points_left >= 1 && points_right <= 2*N - 3; i++, points_left--, points_right++)
        {
            for (int j = 0; j < points_left; j++) Console.Write(".");
            Console.Write("*");
            for (int k = 0; k < points_right; k++) Console.Write(".");
            Console.WriteLine("*");
        }

        for (int i = 0; i < 2 * N; i++) Console.Write("*");
        Console.WriteLine();
    }
}
