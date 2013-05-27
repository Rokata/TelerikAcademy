using System;

class Program
{
    static void Main()
    {
        string[] strings = { "Pesho", "Mitaka", "Kireca", "Mnooooooo dalgiq", "Vankata", "Tosho" };

        Array.Sort(strings, (x, y) => x.Length.CompareTo(y.Length));

        Console.WriteLine("Sorted by length (ascending): ");
        foreach (var item in strings) Console.WriteLine(item);

        Console.WriteLine();

        Array.Sort(strings, (x, y) => y.Length.CompareTo(x.Length));

        Console.WriteLine("Sorted by length (descending): ");
        foreach (var item in strings) Console.WriteLine(item);
    }
}
