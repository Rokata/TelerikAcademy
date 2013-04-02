using System;
using System.Collections.Generic;

class Program
{
    public class Number
    {
        public int number, count;

        public Number(int number, int count)
        {
            this.number = number;
            this.count = count;
        }
    }

    static void Main()
    {
        List<Number> nums = new List<Number>();

        int N = int.Parse(Console.ReadLine());

        for (int i = 0; i < N; i++)
        {
            int current = int.Parse(Console.ReadLine());
            bool isFound = false;

            for (int j = 0; j < nums.Count; j++)
            {
                if (nums[j].number == current)
                {
                    nums[j].count++;
                    isFound = true;
                }
            }

            if (!isFound) nums.Add(new Number(current, 1));
        }

        for (int i = 0; i < nums.Count; i++)
        {
            if (nums[i].count % 2 != 0)
            {
                Console.WriteLine(nums[i].number);
                break;
            }
        }
    }
}