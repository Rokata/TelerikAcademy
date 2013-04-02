using System;
using System.Collections.Generic;

namespace IEnumerableExtension
{
    class IEnumerableDemo
    {
        static void Main()
        {
            List<float> numbers = new List<float>();
            numbers.Add(4.3f);
            numbers.Add(5.2f);
            numbers.Add(1.3f);
            numbers.Add(7.4f);
            numbers.Add(2.2f);

            Console.WriteLine("Sum: {0}", numbers.Sum());
            Console.WriteLine("Min: {0}", numbers.Min());
            Console.WriteLine("Max: {0}", numbers.Max());
            Console.WriteLine("Avg: {0}", numbers.Avg());
            Console.WriteLine("Product: {0}", numbers.Product());
        }
    }
}
