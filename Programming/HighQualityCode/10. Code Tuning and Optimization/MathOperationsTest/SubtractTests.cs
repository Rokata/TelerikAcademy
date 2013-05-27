using System;

namespace MathOperationsTest
{
    static class SubtractTests
    {
        public static void SubtractInt(int startNumber, int endValue, int offset)
        {
            for (int i = startNumber; i > endValue; i -= offset) { }
        }

        public static void SubtractLong(long startNumber, long endValue, long offset)
        {
            for (long i = startNumber; i > endValue; i -= offset) { }
        }

        public static void SubtractFloat(float startNumber, float endValue, float offset)
        {
            for (float i = startNumber; i > endValue; i -= offset) { }
        }

        public static void SubtractDouble(double startNumber, double endValue, double offset)
        {
            for (double i = startNumber; i > endValue; i -= offset) { }
        }

        public static void SubtractDecimal(decimal startNumber, decimal endValue, decimal offset)
        {
            for (decimal i = startNumber; i > endValue; i -= offset) { }
        }
    }
}
