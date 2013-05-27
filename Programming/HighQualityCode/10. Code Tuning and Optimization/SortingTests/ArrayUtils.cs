using System;
using System.Text;

namespace SortingTests
{
    static class ArrayUtils
    {
        private static Random r = new Random();
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static void CreateIntArray(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = r.Next();
        }

        public static void CreateDoubleArray(double[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = r.NextDouble();
        }

        public static void CreateStringArray(string[] strings)
        {
            for (int i = 0; i < strings.Length; i++)
                strings[i] = GenerateStringFromCharArray();
        }

        public static void ReverseArray<T>(T[] elements) where T : IComparable
        {
            Array.Sort(elements, new Comparison<T>(
                    (x, y) => y.CompareTo(x)
                ));
        }

        private static string GenerateStringFromCharArray()
        {
            int length = r.Next(10, 25);
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < length; i++)
                builder.Append(Chars[r.Next(0, Chars.Length)]);

            return builder.ToString();
        }
    }
}
