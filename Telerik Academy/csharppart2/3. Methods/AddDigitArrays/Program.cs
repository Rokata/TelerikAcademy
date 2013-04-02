using System;
using System.Numerics;

namespace AddDigitArrays
{
    class Program
    {
        public static decimal AddDigitArrays(int[] first, int[] second)
        {
            decimal result = 0;
            for (int i = 0; i < first.Length; i++)
            {
                result += (decimal) (first[i] * Math.Pow((double)10, (double)i));
            }

            for (int i = 0; i < second.Length; i++)
            {
                result += (decimal)(second[i] * Math.Pow((double)10, (double)i));
            }

            return result;
        }

        static void Main(string[] args)
        {
            int[] firstNumber = { 5, 3, 6, 1 }; // 1635
            int[] secondNumber = { 2, 1, 0, 4, 8, 1 }; // 184012

            Console.WriteLine("Result: " + AddDigitArrays(firstNumber, secondNumber)); // 185647
        }
    }
}
