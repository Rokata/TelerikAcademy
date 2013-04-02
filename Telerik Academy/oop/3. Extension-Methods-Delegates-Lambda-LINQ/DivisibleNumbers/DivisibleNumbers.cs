using System;
using System.Linq;

namespace DivisibleNumbers
{
    class DivisibleNumbers
    {
        public static int[] GetDivisibleLambda(int[] nums)
        {
            var divisibleNumbers = nums.Where(x => (x % 3 == 0 && x % 7 == 0)).Select(x => x);
            return divisibleNumbers.ToArray<int>();
        }

        public static int[] GetDivisibleLINQ(int[] nums)
        {
            var divisibleNumbers = from number in nums
                                   where number % 3 == 0 && number % 7 == 0
                                   select number;

            return divisibleNumbers.ToArray<int>();
        }

        public static void PrintResult(int[] nums)
        {
            foreach (int item in nums) Console.Write(item + " ");
            Console.WriteLine();
        }
        
        static void Main()
        {
            int[] numbers = { 5, 15, 24, 21, 44, 94, 124, 63, 733, 665, 309 };

            Console.Write("Using lambda: ");
            PrintResult(GetDivisibleLambda(numbers));
            Console.Write("Using LINQ: ");
            PrintResult(GetDivisibleLINQ(numbers));
        }
    }
}
