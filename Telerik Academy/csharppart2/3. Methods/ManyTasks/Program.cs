using System;
using System.Text;

class Program
{
    public static void ReverseDecimal(ref decimal number)
    {
        string numberStr = number.ToString();
        StringBuilder result = new StringBuilder();

        for (int i = numberStr.Length - 1; i >= 0; i--)
        {
            result.Append(numberStr[i]);
        }

        number = decimal.Parse(result.ToString());
    }

    public static double Avg(params int[] numbers)
    {
        int sum = 0;
        foreach (int number in numbers) sum += number;

        return ((double)sum / numbers.Length);
    }

    public static void SolveLinearEquation()
    {
        int a, b;

        do
        {
            Console.Write("a=? (must not be equal to 0) ");
            a = int.Parse(Console.ReadLine());
        } while (a == 0);

        Console.Write("b=? ");
        b = int.Parse(Console.ReadLine());

        Console.WriteLine("x = " + (double)(b * -1) / a);
    }

    static void Main()
    {
        byte choice;

        do
        {
            do
            {
                Console.WriteLine("To reverse the digits of decimal number, press 1");
                Console.WriteLine("To find out the average of certain sequence, press 2");
                Console.WriteLine("To solve an a*x + b = 0 equation, press 3");
                Console.WriteLine("To exit, press 0");

                choice = byte.Parse(Console.ReadLine());

            } while (choice < 0 && choice > 3);

            switch (choice)
            {
                case 1:
                    decimal numberToReverse = 0;

                    do
                    {
                        Console.Write("Enter number to reverse (must be non-negative!): ");
                        numberToReverse = decimal.Parse(Console.ReadLine());
                    } while (numberToReverse < 0);

                    ReverseDecimal(ref numberToReverse);
                    Console.WriteLine("\nThe number reversed is: " + numberToReverse + "\n");
                    break;

                case 2:
                    int count = 0;

                    do
                    {
                        Console.Write("How many numbers will the sequence consist of? (must be positive number!) ");
                        count = int.Parse(Console.ReadLine());
                    } while (count <= 0);

                    int[] parameters = new int[count];

                    for (int i = 0; i < count; i++)
                    {
                        Console.Write("Enter a number: ");
                        parameters[i] = int.Parse(Console.ReadLine());
                    }

                    Console.WriteLine("\nAvg value of sequence: " + Avg(parameters) + "\n");
                    break;

                case 3:
                    SolveLinearEquation();
                    break;
            }
        } while (choice != 0);
    }
}
