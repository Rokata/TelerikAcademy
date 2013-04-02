using System;

class Program
{
    public static int ParseAndSum(string str)
    {
        string[] numbers = str.Split(' ');
        int sum = 0;

        foreach (string value in numbers)
        {
            sum += int.Parse(value);
        }
        return sum;
    }

    static void Main()
    {
        string nums = "1 7 3 10 8 3";
        Console.WriteLine(ParseAndSum(nums));
    }
}
