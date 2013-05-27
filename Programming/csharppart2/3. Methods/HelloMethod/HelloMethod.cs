using System;

class HelloMethod
{
    public static void HelloStranger()
    {
        Console.Write("What's your name? ");
        string name = Console.ReadLine();
        Console.WriteLine("Hello, " + name + "!");
    }

    static void Main()
    {
        HelloStranger();
    }
}
