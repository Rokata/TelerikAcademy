using System;

class Matrix
{
    static void Main()
    {
        int N = 5;
        int increment = 0;

        for (int i = 1; i <= N; i++)
        {
            increment = i;
            for (int j = 1; j <= 3; j++, increment++)
            {
                Console.Write(increment);
            }
            Console.WriteLine();
        }
    }
}
