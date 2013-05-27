using System;
using System.Text;
using System.Collections.Generic;

class Program
{
    public static int AnyToDec(string number, int s)
    {
        if (s == 2 || s == 8 || s == 10 || s == 16)
        {
            return Convert.ToInt32(number, s);
        }

        int dec = 0;
        char[] numberArray = number.ToCharArray();
        Array.Reverse(numberArray);

        for (int i = 0; i < numberArray.Length; i++)
        {
            int intValue = 0;

            if (numberArray[i] >= 'a' && numberArray[i] <= 'e')
            {
                switch (numberArray[i])
                {
                    case 'a': intValue = 10; break;
                    case 'b': intValue = 11; break;
                    case 'c': intValue = 12; break;
                    case 'd': intValue = 13; break;
                    case 'e': intValue = 14; break;
                    default: Console.WriteLine("Error!"); break;
                    /* case 'F' is not necessary because it will be needed only if s = 16
                     * and in that case Convert.ToInt32(number, s); is called istead of this
                     * */
                }
            }
            else
            {
                intValue = int.Parse(numberArray[i].ToString());
            }

            if (intValue != 0)
            {
                for (int j = 0; j < i; j++)
                {
                    intValue *= s;
                }
            }

            dec += intValue;
        }

        return dec;
    }

    public static string DecToAny(int dec, int sbase)
    {
        if (sbase == 2 || sbase == 8 || sbase == 10 || sbase == 16) {
            return Convert.ToString(dec, sbase);
        }

        StringBuilder result = new StringBuilder();
        while (dec > 0)
        {
            int remainder = dec % sbase;
            dec /= sbase;

            if (remainder >= 10 && remainder <= 14)
            {
                switch (remainder)
                {
                    case 10: result.Append("a"); break;
                    case 11: result.Append("b"); break;
                    case 12: result.Append("c"); break;
                    case 13: result.Append("d"); break;
                    case 14: result.Append("e"); break;
                    default: Console.WriteLine("Error!"); break;
                }
                continue;
            }        
            result.Append(remainder);
        }

        char[] arrayResult = result.ToString().ToCharArray();
        Array.Reverse(arrayResult);
        return new string(arrayResult);
    }

    static void Main()
    {
        int dec = 0;
        Console.Write("s = ");
        int s = int.Parse(Console.ReadLine());

        Console.Write("d = ");
        int d = int.Parse(Console.ReadLine());

        if (s == d || s < 2 || d > 16)
        {
            Console.WriteLine("Are you f**king kidding with me?!");
            return;
        }

        Console.Write("Enter number in {0}-numeral system ", s);
        string number = Console.ReadLine();

        dec = AnyToDec(number, s);

        string finalResult = DecToAny(dec, d);
        Console.WriteLine("{0}-demical equivalent: {1}", d ,finalResult);

    }
}
