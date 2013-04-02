using System;

class Program
{
    public static int Min(params int[] numbers) {
        int min = numbers[0];

        foreach (int num in numbers)
        {
            if (num < min) min = num;
        }
        return min;
    }

    public static int Max(params int[] numbers)
    {
        int max = numbers[0];

        foreach (int num in numbers)
        {
            if (num > max) max = num;
        }
        return max;
    }

    public static double Avg(params int[] numbers)
    {
        return ((double) Sum(numbers) / numbers.Length);
    }

    public static int Sum(params int[] numbers)
    {
        int sum = 0;
        foreach (int num in numbers) sum += num;

        return sum;
    }

    public static decimal Product(params int[] numbers)
    {
        decimal product = 1;

        foreach (int num in numbers) product *= (decimal)num;
        return product;
    }

    static void Main()
    {
        Console.WriteLine("Min: " + Min(4, 6, 9, 1, 4, -3));
        Console.WriteLine("Max: " + Max(11, 5, 103, 1003, 89, 999));
        Console.WriteLine("Sum: " + Sum(45, 76, 98, 11, 9));
        Console.WriteLine("Avg: " + Avg(5, 11, 9, 12));
        Console.WriteLine("Product: " + Product(5, 1, 19, 54));
    }
}
