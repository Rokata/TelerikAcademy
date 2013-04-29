using System;

namespace AdvancedMathTests
{
    static class SqrtTests
    {
        public static void SqrtFloat()
        {
            for (float i = 10000000f; i >= 1f; i--)
                Math.Sqrt(i);
        }

        public static void SqrtDouble()
        {
            for (double i = 10000000d; i >= 1d; i--)
                Math.Sqrt(i);
        }

        public static void SqrtDecimal()
        {
            for (decimal i = 10000000m; i >= 1m; i--)
                Math.Sqrt((double)i);
        }
    }
}
