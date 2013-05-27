using System;

class Primality
{
    static void Main()
    {
        Console.Write("Enter number: ");
        int n = int.Parse(Console.ReadLine());

        bool isPrime = ((n != 2) && (n != 3) && (n != 5) && (n != 7)) && ((n % 2 == 0) || (n % 3 == 0) || (n % 5 == 0) ||
            (n % 7 == 0)) ? false : true;

        Console.WriteLine((isPrime == true) ? "Prime" : "Composite");
    }
}
