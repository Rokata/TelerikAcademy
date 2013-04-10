using System;

namespace BoolToStringClass
{
    class Program
    {
        const int MaxCount = 6;

        class BoolPrinter
        {
            public void PrintBoolAsString(bool value)
            {
                string boolAsString = value.ToString();
                Console.WriteLine(boolAsString);
            }
        }

        static void Main()
        {
            BoolPrinter printer = new BoolPrinter();
            printer.PrintBoolAsString(true);
        }
    }
}
