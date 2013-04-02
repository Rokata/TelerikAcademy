using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    public static int[] SubtractPolynomals(int[] first, int[] second)
    {
        int[] result;

        if (first.Length < second.Length)
        {
            result = new int[second.Length];
            for (int i = 0; i < second.Length; i++)
            {
                if (i >= first.Length)
                {
                    result[i] = second[i] * -1;
                    continue;
                }
                result[i] = first[i] - second[i];
            }
        }

        else
        {
            result = new int[first.Length];
            for (int i = 0; i < first.Length; i++)
            {
                if (i >= second.Length)
                {
                    result[i] = first[i] * -1;
                    continue;
                }
                result[i] = first[i] - second[i];
            }
        }
        return result;
    }

    public static int[] MultiplicatePolynomals(int[] first, int[] second)
    {
        int biggestPower = (first.Length - 1) * (second.Length - 1);
        int[] result = new int[biggestPower];

        for (int i = 0; i < first.Length; i++)
        {
            for (int j = 0; j < second.Length; j++)
            {
                int power = i + j;
                result[power] += first[i] * second[j];
            }
        }

        return result;
    }

    static void Main()
    {
        int[] coefsFirst = { 4, 0, 4 };
        int[] coefsSecond = { 1, 10, 5, 5, 2 };

        int[] result = SubtractPolynomals(coefsFirst, coefsSecond);

        Console.Write("Polynomal 1 - Polynomal 2: ");

        for (int i = result.Length - 1; i >= 0; i--)
        {
            if (i == 0)
            {
                Console.WriteLine(result[i]);
                break;
            }

            if (result[i] != 0) Console.Write("(" + result[i] + ")" + "x" + i + " + ");
        }

        result = MultiplicatePolynomals(coefsFirst, coefsSecond);

        Console.Write("Polynomal 1 x Polynomal 2: ");

        for (int i = result.Length - 1; i >= 0; i--)
        {
            if (i == 0)
            {
                Console.WriteLine(result[i]);
                break;
            }

            if (result[i] != 0) Console.Write("(" + result[i] + ")" + "x" + i + " + ");
        }
    }
}
