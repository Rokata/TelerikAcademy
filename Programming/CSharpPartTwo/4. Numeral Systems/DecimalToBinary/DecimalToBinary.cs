using System;
using System.Text;

class DecimalToBinary
{
    static void Main()
    {    
        Console.Write("Enter decimal number: ");
        int decimalNumber = int.Parse(Console.ReadLine());
      
        Console.WriteLine("Binary presentation: " + Convert.ToString(decimalNumber, 2));
    }
}
