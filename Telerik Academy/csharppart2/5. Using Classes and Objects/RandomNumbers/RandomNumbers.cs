using System;

class Program
{
    static void Main()
    {
        Random r = new Random();

        Console.Write("Random values: ");

        for (int i = 0; i < 10; i++) Console.Write(r.Next(100, 200) + " ");
        Console.WriteLine();
    }
}