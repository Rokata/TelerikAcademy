using System;

namespace MathOperationsTest
{
    static class IncrementTests
    {
        public static void IncrementInt(int startNumber, int endValue)
        {
            for (int i = startNumber; i < endValue; i++) { }
        }

        public static void IncrementLong(long startNumber, long endValue)
        {
            for (long i = startNumber; i < endValue; i++) { }
        }

        public static void IncrementFloat(float startNumber, float endValue)
        {
            for (float i = startNumber; i < endValue; i++) { }
        }

        public static void IncrementDouble(double startNumber, double endValue)
        {
            for (double i = startNumber; i < endValue; i++) { }
        }

        public static void IncrementDecimal(decimal startNumber, decimal endValue)
        {
            for (decimal i = startNumber; i < endValue; i++) { }
        }
    }
}
