using System;

class BiggestOfThreeIntegers
{
    static void Main()
    {
        int a = 8, b = 9, c = 11;

        if (a > b)
        {
            if (b > c) Console.WriteLine("The biggest of the three is {0}", a);
            if (b < c)
            {
                if (a > c) Console.WriteLine("The biggest of the three is {0}", a);
                else Console.WriteLine("The biggest of the three is {0}", c);
            }
        }
        else
        {
            if (b > c) Console.WriteLine("The biggest of the three is {0}", b);
            else Console.WriteLine("The biggest of the three is {0}", c);
        }

    }
}
