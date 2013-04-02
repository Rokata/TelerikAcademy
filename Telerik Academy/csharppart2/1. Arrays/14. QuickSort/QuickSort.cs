using System;

class Quick_Sort
{
    public static void QuickSort(string[] items, int left, int right)
    {
        int i, j;
        string x, temp;

        i = left;
        j = right;
        x = items[(left + right) / 2];

        do
        {
            while (items[i].CompareTo(x) < 0 && i < right)
            {
                i++;
            }

            while (items[j].CompareTo(x) > 0 && j > left)
            {
                j--;
            }

            if (i <= j)
            {
                temp = items[i];
                items[i] = items[j];
                items[j] = temp;
                i++;
                j--;
            }
        } while (i <= j);


        if (left < j)
        {
            QuickSort(items, left, j);
        }
        if (i < right)
        {
            QuickSort(items, i, right);
        }
    }

    static void Main()
    {
        string[] names = { "Pesho", "Atanas", "Niko", "Ivan", "Mitko", "Gosho" };

        QuickSort(names, 0, names.Length - 1);

        Console.WriteLine("Array sorted: ");
        foreach (string name in names) Console.WriteLine(name);
    }
}
