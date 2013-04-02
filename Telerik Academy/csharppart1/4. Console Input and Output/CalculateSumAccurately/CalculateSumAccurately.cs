using System;

class CalculateSumAccurately
{
    static void Main(string[] args)
    {
        double sum = 1.0;
        int k = 1;

        for (double i = 2; 1 / i > 0.001; i++)
        {
            sum += 1 / (k * i);
            k = k * (-1);
        }

        Console.WriteLine("Sum of sequence 1, 1/2, -1/3, 1/4, -1/5... is {0:0.###}", sum);
    }
}
