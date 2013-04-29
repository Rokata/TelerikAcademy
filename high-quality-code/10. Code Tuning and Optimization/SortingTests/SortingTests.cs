using System;

namespace SortingTests
{
    class SortingTests
    {
        static void Main()
        {
            string[] strings = new string[5000];

            ArrayUtils.CreateStringArray(strings);
            ArrayUtils.ReverseArray(strings);

            Sorting.QuickSort((string[])strings.Clone());
            Sorting.InsertionSort((string[])strings.Clone());
            Sorting.SelectionSort((string[])strings.Clone());
        }
    }
}
