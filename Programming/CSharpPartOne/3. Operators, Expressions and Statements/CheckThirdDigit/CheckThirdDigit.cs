using System;

class CheckThirdDigit
{
    static void Main()
    {
        int n = 651700;
        Console.WriteLine("Third digit is 7: {0}", (n % 1000 >= 700 && n % 1000 <= 799) ? true : false);
    }
}
