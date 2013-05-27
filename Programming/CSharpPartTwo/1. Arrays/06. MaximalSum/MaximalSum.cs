using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MaximalSum
{
    static void Main()
    {
        Console.Write("N=? ");
        int N = int.Parse(Console.ReadLine());
        Console.Write("K=? ");
        int K = int.Parse(Console.ReadLine());

        int[] array = new int[N];
        List<int> elements = new List<int>();

        for (int i = 0; i < N; i++) array[i] = int.Parse(Console.ReadLine());

        Array.Sort<int>(array,
                    new Comparison<int>(
                            (i1, i2) => i2.CompareTo(i1)
                    ));

        for (int i = 0; i < K; i++) elements.Add(array[i]);

        StringBuilder result = new StringBuilder();
        result.Append("{");

        foreach (int item in elements) result.Append(item + ", ");
        result.Remove(result.Length - 2, 2);
        result.Append("}");

        Console.WriteLine("{0} (Sum: {1})", result, elements.Sum());
    }
}
