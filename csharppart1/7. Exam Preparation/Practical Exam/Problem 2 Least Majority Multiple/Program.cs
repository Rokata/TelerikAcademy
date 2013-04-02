using System;

class Program
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());
        int e = int.Parse(Console.ReadLine());

        int majorityMultiple = 4;

        while (true)
        {
            int count = 0;

            if (majorityMultiple % a == 0) count++;
            if (majorityMultiple % b == 0) count++;
            if (majorityMultiple % c == 0) count++;
            if (majorityMultiple % d == 0) count++;
            if (majorityMultiple % e == 0) count++;

            if (count >= 3) break;
            else majorityMultiple++;
        }

        Console.WriteLine(majorityMultiple);
    }
}
