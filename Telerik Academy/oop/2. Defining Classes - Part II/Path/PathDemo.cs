using System;
using System.Collections.Generic;

namespace PathNamespace
{
    class Program
    {
        static void Main()
        {
            Path_ p = PathStorage.ReadFromFile("input.txt");
            PathStorage.SaveToFile(p);
        }
    }
}
