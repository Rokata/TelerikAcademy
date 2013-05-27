using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOperationsTest
{
    static class DivisionTests
    {
        public static void DivideInt(int startNumber, int endValue, int offset)
        {
            for (int i = startNumber; i > endValue; i /= offset) { }
        }

        public static void DivideLong(long startNumber, long endValue, long offset)
        {
            for (long i = startNumber; i > endValue; i /= offset) { }
        }

        public static void DivideFloat(float startNumber, float endValue, float offset)
        {
            for (float i = startNumber; i > endValue; i /= offset) { }
        }

        public static void DivideDouble(double startNumber, double endValue, double offset)
        {
            for (double i = startNumber; i > endValue; i /= offset) { }
        }

        public static void DivideDecimal(decimal startNumber, decimal endValue, decimal offset)
        {
            for (decimal i = startNumber; i > endValue; i /= offset) { }
        }
    }
}
