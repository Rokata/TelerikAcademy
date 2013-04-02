using System;

class Program
{
    public static string LastDigitToString(int number)
    {
        switch (number % 10)
        {
            case 0: return "null"; 
            case 1: return "one"; 
            case 2: return "two"; 
            case 3: return "three"; 
            case 4: return "four"; 
            case 5: return "five"; 
            case 6: return "six"; 
            case 7: return "seven"; 
            case 8: return "eight"; 
            case 9: return "nine";
            default: return null;
        }
    }

    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("Last digit is spelled: " + LastDigitToString(number));
    }
}
