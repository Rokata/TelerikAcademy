using System;

class PrintSequence
{
    static void Main()
    {
        for (int i = 1; i <= 10; i++)
        {
            if ((i + 1) % 2 == 0) Console.WriteLine(i + 1);
            else Console.WriteLine((i + 1) * -1);
        }
    }
}
