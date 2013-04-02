using System;

class DivisionBy5_7Expression
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        bool canBeDivided = (n % 5 == 0 && n % 7 == 0) ? true : false;
        Console.WriteLine(canBeDivided);
    }
}
