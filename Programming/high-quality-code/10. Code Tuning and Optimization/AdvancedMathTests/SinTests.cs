using System;

namespace AdvancedMathTests
{
    static class SinTests
    {
        public static void SinFloat()
        {
            for (float i = 1000000f; i >= 1f; i--)
                Math.Sin(i);
        }

        public static void SinDouble()
        {
            for (double i = 1000000d; i >= 1d; i--)
                Math.Sin(i);
        }

        public static void SinDecimal()
        {
            for (decimal i = 1000000m; i >= 1m; i--)
                Math.Sin((double)i);
        }
    }
}
