using System;
using System.Text;

class MergeSort
{
    public static void M_Sort(int[] numbers, int[] temp, int left, int right) 
    {
        int mid;

        if (right > left)
        {
            mid = (right + left) / 2;
            M_Sort(numbers, temp, left, mid);
            M_Sort(numbers, temp, mid + 1, right);
            Merge(numbers, temp, left, mid + 1, right);
        }
    }

    public static void Merge(int[] numbers, int[] temp, int left, int mid, int right)
    {
        int left_end, num_elements, tmp_pos;
        left_end = mid - 1;
        tmp_pos = left;
        num_elements = right - left + 1;

        while (left <= left_end && mid <= right)
        {
            if (numbers[left] <= numbers[mid])
            {
                temp[tmp_pos] = numbers[left];
                tmp_pos++;
                left++;
            }
            else
            {
                temp[tmp_pos] = numbers[mid];
                tmp_pos++;
                mid++;
            }
        }

        while (left <= left_end)
        {
            temp[tmp_pos] = numbers[left];
            left++;
            tmp_pos++;
        }

        while (mid <= right)
        {
            temp[tmp_pos] = numbers[mid];
            mid++;
            tmp_pos++;
        }

        for (int i = 0; i < num_elements; i++)
        {
            numbers[right] = temp[right];
            right--;
        }
    }

    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[] nums = new int[N];
        int[] temp = new int[N];

        for (int i = 0; i < N; i++) nums[i] = int.Parse(Console.ReadLine());

        M_Sort(nums, temp, 0, nums.Length - 1);

        StringBuilder result = new StringBuilder();
        result.Append("{");

        foreach (int i in nums) result.Append(i + ", ");

        result.Remove(result.Length - 2, 2);
        result.Append("}");

        Console.WriteLine(result);
    }
}
