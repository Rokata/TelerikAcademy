using System;

class ReadAndCalculateAge
{
    static void Main()
    {
        Console.Write("Enter your age: ");
        int age = int.Parse(Console.ReadLine());

        Console.WriteLine("After 10 years you will be {0}", (age + 10));
    }
}
