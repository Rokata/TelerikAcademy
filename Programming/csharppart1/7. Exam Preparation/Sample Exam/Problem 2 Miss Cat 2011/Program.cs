using System;

class Program
{
    static void Main()
    {
        uint N = uint.Parse(Console.ReadLine());
        uint[] cats = new uint[10];

        for (int i = 0; i < N; i++)
        {
            uint vote = uint.Parse(Console.ReadLine());
            cats[vote - 1]++;
        }

        int winner = 0;
        for (int i = 1; i < cats.Length; i++)
        {
            if (cats[i] > cats[winner]) winner = i;
        }

        Console.WriteLine(winner + 1);
    }
}

