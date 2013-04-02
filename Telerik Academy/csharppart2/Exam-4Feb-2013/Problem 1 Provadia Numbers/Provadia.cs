using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        List<string> digits = new List<string>();

        string[] alphabet = new string[256];
        char append = 'a';
        char main = 'A';

        // Generate alphabet

        for (int i = 0; i < 256; i++)
        {
            if (i % 26 == 0 && i > 0)
            {
                append++;
                main = 'A';
            }

            if (i >= 0 && i <= 25) alphabet[i] = (main++).ToString();
            else alphabet[i] = ((char)(append - 1)) + (main++).ToString();
        }

        if (N < 256)
        {
            Console.WriteLine(alphabet[N]);
            return;
        }

        else
        {
            digits.Add(alphabet[N % 256]);
            int rest = N / 256;
            digits.Add(alphabet[rest]);
        }


        StringBuilder sb = new StringBuilder();

        for (int i = digits.Count - 1; i >= 0; i--)
        {
            sb.Append(digits[i]);
        }

        Console.WriteLine(sb.ToString());
    }
}