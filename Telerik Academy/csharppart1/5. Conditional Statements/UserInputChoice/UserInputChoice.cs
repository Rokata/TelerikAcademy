using System;

class UserInputChoice
{
    static void Main()
    {
        int choice = 0;
        object value = null;

        Console.WriteLine("1. int");
        Console.WriteLine("2. double");
        Console.WriteLine("3. string");

        if (!int.TryParse(Console.ReadLine(), out choice)) {
            Console.WriteLine("Invalid input!");
            return;
        }

        switch (choice)
        {
            case 1: Console.Write("Input an integer... ");
                value = int.Parse(Console.ReadLine());
                value = int.Parse(value.ToString()) + 1;
                break;
            case 2: Console.Write("Input a double value... ");
                value = double.Parse(Console.ReadLine());
                value = double.Parse(value.ToString()) + 1;
                break;
            case 3: Console.Write("Input a string... ");
                value = Console.ReadLine();
                value = value.ToString() + "*";
                break;
            default: Console.WriteLine("Invalid choice!"); break;
        }

        Console.WriteLine(value.ToString());
    }
}


