using System;


class ExchangeValues
{
    static void Main()
    {
        int temp;
        int a = 7;
        int b = 5;

        if (a > b)
        {
            temp = a;
            a = b;
            b = temp;
        }

        Console.WriteLine("a = {0} , b = {1}", a, b);
    }
}
