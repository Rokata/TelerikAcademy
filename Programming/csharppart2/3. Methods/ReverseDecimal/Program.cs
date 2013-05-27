using System;
using System.Text;

namespace ReverseDecimal
{
    class Program
    {
        public static void ReverseDecimal(ref decimal number)
        {
            string numberStr = number.ToString();
            StringBuilder result = new StringBuilder();

            for (int i = numberStr.Length-1; i >= 0; i--)
            {
                result.Append(numberStr[i]);
            }

            number = decimal.Parse(result.ToString());
        }

        static void Main()
        {
            Console.Write("Enter number: ");
            decimal d = decimal.Parse(Console.ReadLine());
            ReverseDecimal(ref d);

            Console.WriteLine("Number in reversed order: " + d);
        }
    }
}
