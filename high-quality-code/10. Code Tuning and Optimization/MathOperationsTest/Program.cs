using System;
using System.Diagnostics;

namespace MathOperationsTest
{
    class Program
    {
        static void Main()
        {
            DivisionTests.DivideInt(1000000000, 1, 3);
            DivisionTests.DivideLong(1000000000L, 1L, 3L);
            DivisionTests.DivideFloat(1000000000f, 1f, 3f);
            DivisionTests.DivideDouble(1000000000.0, 1.0, 3.0);
            DivisionTests.DivideDecimal(1000000000m, 1m, 3m);
        }
    }
}
