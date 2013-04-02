using System;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int M = int.Parse(Console.ReadLine());
        int possibleBestSize = 1;
        int bestSize = 0;
        bool canBeDividedToM = false, canBeDividedPrev = false;

        int[] sizes = new int[N];

        for (int i = 0; i < N; i++) sizes[i] = int.Parse(Console.ReadLine());

        while (true)
        {
            int pieces = 0;

            for (int i = 0; i < N; i++)
            {
                pieces += sizes[i] / possibleBestSize;

                if (pieces > M) break;
            }

            if (pieces == M)
            {
                canBeDividedToM = true;
                if (possibleBestSize > bestSize) bestSize = possibleBestSize;
            }

            if (!canBeDividedToM && canBeDividedPrev) break; 

            canBeDividedPrev = canBeDividedToM;
            canBeDividedToM = false;
            possibleBestSize++;
        }

        Console.WriteLine(bestSize);
    }
}
