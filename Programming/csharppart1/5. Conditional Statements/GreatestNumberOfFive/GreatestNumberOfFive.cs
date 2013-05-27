using System;

class GreatestNumberOfFive
{
    static void Main()
    {
        int a = 84, b = 12, c = 55, d = 19, e = 26;

        if (a > b && a > c && a > d && a > e)
            Console.WriteLine("The greatest is a={0}", a);
        else if (b > a && b > c && b > d && b > e)
            Console.WriteLine("The greatest is b={0}", b);
        else if (c > a && c > b && c > d && c > e)
            Console.WriteLine("The greatest is c={0}", c);
        else if (d > a && d > b && d > c && d > e)
            Console.WriteLine("The greatest is d={0}", d);
        else
            Console.WriteLine("The greatest is e={0}", e);

    }
}
