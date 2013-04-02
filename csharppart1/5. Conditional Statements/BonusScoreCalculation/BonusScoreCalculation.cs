using System;

class BonusScoreCalculation
{
    static void Main()
    {
        int n;
        try
        {
            Console.Write("Enter score: ");
            n = int.Parse(Console.ReadLine());
            if (n == 0) throw new FormatException();
        }
        catch (FormatException e)
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        switch (n)
        {
            case 1: n *= 10; break;
            case 2: n *= 10; break;
            case 3: n *= 10; break;
            case 4: n *= 100; break;
            case 5: n *= 100; break;
            case 6: n *= 100; break;
            case 7: n *= 1000; break;
            case 8: n *= 1000; break;
            case 9: n *= 1000; break;
            default: Console.WriteLine("Value is too big."); return;
        }

        Console.WriteLine("New score: " + n);
    }
}
