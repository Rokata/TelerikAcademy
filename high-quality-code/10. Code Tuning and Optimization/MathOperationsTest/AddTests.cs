using System;

namespace MathOperationsTest
{
    static class AddTests
    {
        public static void AddInt(int startNumber, int endValue, int offset)
        {
            for (int i = startNumber; i < endValue; i += offset) { }
        }

        public static void AddLong(long startNumber, long endValue, long offset)
        {
            for (long i = startNumber; i < endValue; i += offset) { }
        }

        public static void AddFloat(float startNumber, float endValue, float offset)
        {
            for (float i = startNumber; i < endValue; i += offset) { }
        }

        public static void AddDouble(double startNumber, double endValue, double offset)
        {
            for (double i = startNumber; i < endValue; i += offset) { }
        }

        public static void AddDecimal(decimal startNumber, decimal endValue, decimal offset)
        {
            for (decimal i = startNumber; i < endValue; i += offset) { }
        }
    }
}
