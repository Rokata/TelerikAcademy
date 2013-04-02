using System;

class QuadraticEquationSolve
{
    static void Main()
    {
        double D;
        double x1 = 0, x2 = 0;
        double a, b, c;

        Console.Write("a=? ");
        if (!double.TryParse(Console.ReadLine(), out a)) { Console.WriteLine("Invalid input!"); return; }

        Console.Write("b=? ");
        if (!double.TryParse(Console.ReadLine(), out b)) { Console.WriteLine("Invalid input!"); return; }

        Console.Write("c=? ");
        if (!double.TryParse(Console.ReadLine(), out c)) { Console.WriteLine("Invalid input!"); return; }

        D = b * b - 4 * a * c;

        if (D < 0 || (a == 0 && b == 0 && c != 0))
        {
            Console.WriteLine("No roots.");
            return;
        }
        else
        {
            if (D > 0)
            {
                if (a != 0)
                {
                    x1 = (b * -1 + Math.Sqrt(D)) / (2 * a);
                    x2 = (b * -1 - Math.Sqrt(D)) / (2 * a);
                }
                else
                {
                    x1 = x2 = (c * -1) / b;
                }
            }

            if (D == 0)
            {
                if (a == 0 && b == 0 && c == 0)
                {
                    Console.WriteLine("Every x is a root");
                    return;
                }
                else x1 = x2 = -b / (2 * a);
            }
        }

        Console.WriteLine("x1 = {0} , x2 = {1}", x1, x2);
    }
}
