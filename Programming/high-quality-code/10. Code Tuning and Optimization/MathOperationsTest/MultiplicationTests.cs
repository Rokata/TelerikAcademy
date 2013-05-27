using System;

namespace MathOperationsTest
{
    static class MultiplicationTests
    {
        public static void MultiplyInt(int startNumber, int endValue, int offset)
        {
            for (int i = startNumber; i < endValue; i *= offset) { }
        }

        public static void MultiplyLong(long startNumber, long endValue, long offset)
        {
            for (long i = startNumber; i < endValue; i *= offset) { }
        }

        public static void MultiplyFloat(float startNumber, float endValue, float offset)
        {
            for (float i = startNumber; i < endValue; i *= offset) { }
        }

        public static void MultiplyDouble(double startNumber, double endValue, double offset)
        {
            for (double i = startNumber; i < endValue; i *= offset) { }
        }

        public static void MultiplyDecimal(decimal startNumber, decimal endValue, decimal offset)
        {
            for (decimal i = startNumber; i < endValue; i *= offset) { }
        }
    }
}
