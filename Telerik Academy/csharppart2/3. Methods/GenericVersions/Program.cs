using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    public static T Min<T>(params T[] numbers) where T: IComparable<T>
    {
        T min = numbers[0];

        foreach (T num in numbers)
        {
            if (num.CompareTo(min) < 0) min = num;
        }
        return min;
    }

    public static T Max<T>(params T[] numbers) where T: IComparable<T>
    {
        T max = numbers[0];

        foreach (T num in numbers)
        {
            if (num.CompareTo(max) > 0) max = num;
        }
        return max;
    }

    public static T Avg<T>(params T[] numbers)
    {
        dynamic sum = Sum(numbers);
        dynamic count = numbers.Length;
        return (sum / count);
    } 

    public static T Sum<T>(params T[] numbers)
    {
        dynamic[] nums = new dynamic[numbers.Length];
        dynamic sum = 0;

        numbers.CopyTo(nums, 0);

        foreach (dynamic num in nums) sum += num;

        return sum;
    }

    public static T Product<T>(params T[] numbers)
    {
        dynamic[] nums = new dynamic[numbers.Length];
        dynamic product = 1;

        numbers.CopyTo(nums, 0);

        foreach (dynamic num in numbers) product *= num;
        return product;
    } 

    static void Main()
    {
        Console.WriteLine("Product with floating-point: " + Product(4.2, 3.3, 2));
        Console.WriteLine("Product with integers: " + Product(3, 5, 2, 11));
        Console.WriteLine("Min with integers: " + Min(4, 3, 11, 1, 8, 3));
        Console.WriteLine("Max with integers: " + Max(4, 3, 11, 1, 8, 3));
        Console.WriteLine("Max with floating-point: " + Max(4.2, 4.21, 11, 11.001, 11.000001, 1, 8, 3));
        Console.WriteLine("Avg with floating-point: " + Avg(3.4, 1.2, 1.2111, 3.44));
    }
}
