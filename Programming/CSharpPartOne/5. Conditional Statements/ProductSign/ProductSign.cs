using System;

class ProductSign
{
    static void Main()
    {
        double a = -5.2;
        double b = 4.2;
        double c = 1.0;

        if ((a > 0 && b > 0 && c > 0) || (a > 0 && b < 0 && c < 0) || (a < 0 && b < 0 && c > 0) ||
            (a < 0 && b > 0 && c < 0))
        {
            Console.WriteLine("+");
        }
        else Console.WriteLine("-");
    }
}
