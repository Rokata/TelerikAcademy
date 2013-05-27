using System;

class Program
{
    static void Main(string[] args)
    {
        double N = double.Parse(Console.ReadLine());
        double M = double.Parse(Console.ReadLine());
        double P = double.Parse(Console.ReadLine());

        Console.WriteLine("{0:0.000000}", ((N * N + (1 / M * P) + 1337) / (N - 128.523123123 * P)) + 
            Math.Sin(M % 180));
    }
}
