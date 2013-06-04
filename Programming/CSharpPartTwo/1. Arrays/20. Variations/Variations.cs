using System;
using System.Collections.Generic;

class Variations
{
    static void Main()
    {
        Console.Write("N=? ");
        int N = int.Parse(Console.ReadLine());
        Console.Write("K=? ");
        int K = int.Parse(Console.ReadLine());
        int index = K - 1;
        int oldValue = 0;

        List<int> nums = new List<int>();
        for (int i = 0; i < K; i++) nums.Add(1);

        while (true)
        { 
            foreach (int item in nums) Console.Write(item + " ");
            Console.WriteLine();

            // the loop executes while there are positions with max value reached
            while (index > -1 && nums[index] == N)
            {
                oldValue = nums[index]; // old value needed to check whether all positions contain max value
                nums[index] = 1; // resets the value corresponding to the index as max value is reached
                --index; 
            }

            if (index == -1 && oldValue == N) break;

            ++nums[index];
            index = K - 1;
        }
    }
}
