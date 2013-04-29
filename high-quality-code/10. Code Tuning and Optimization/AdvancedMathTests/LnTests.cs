using System;

namespace AdvancedMathTests
{
    static class LnTests
    {
        public static void LnFloat()
        {
            for (float i = 1000000f; i >= 1f; i--)
                Math.Log(i, Math.E);
        }

        public static void LnDouble()
        {
            for (double i = 1000000d; i >= 1d; i--)
                Math.Log(i, Math.E);
        }

        public static void LnDecimal()
        {
            for (decimal i = 1000000m; i >= 1m; i--)
                Math.Log((double)i, Math.E);
        }
    }
}
