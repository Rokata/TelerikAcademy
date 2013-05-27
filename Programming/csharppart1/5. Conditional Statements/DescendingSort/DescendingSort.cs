using System;


class DescendingSort
{
    static void Main()
    {
        double a = 1111.0;
        double b = 1111.0;
        double c = 1111.2;
        double temp, temp2;

        if (a > b)
        {
            if (b < c)
            {
                if (a > c)
                {
                    temp = b;
                    b = c;
                    c = temp;
                }
                else
                {
                    temp = c;
                    temp2 = a;
                    c = b;
                    a = temp;
                    b = temp2;
                }
            }
        }
        else
        {
            if (b > c)
            {
                if (a > c)
                {
                    temp = a;
                    a = b;
                    b = temp;
                }
                else
                {
                    temp = c;
                    c = a;
                    a = b;
                    b = temp;
                }
            }
            else
            {
                temp = a;
                a = c;
                c = temp;
            }
        }

        Console.WriteLine("a={0}, b={1}, c={2}", a, b, c);
    }
}
