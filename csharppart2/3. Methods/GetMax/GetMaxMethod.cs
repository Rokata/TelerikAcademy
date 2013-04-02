using System;

class GetMaxMethod
{
    public static int GetMax(int a, int b)
    {
        return (a > b) ? a : b;
    }

    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Max: " + GetMax(GetMax(a, b), c));
    }
}
