using System;
class PrintAllFromOneToN
{
    static void Main()
    {
        int n;
        Console.Write("n=? ");
        
        if (!int.TryParse(Console.ReadLine(), out n))
        {
            Console.WriteLine("Invalid input!");
            return;
        }

        for (int i = 1; i <= n; i++) Console.WriteLine(i);
    }
}
