using System;

class LexicographicCompare
{
    static void Main()
    {   
        char[] chars1 = { 'a', 'b', 'c', 'd', 'z'};
        char[] chars2 = { 'a', 'b', 'c', 'd', 'z', 'a' };

        int smallerLength = (chars1.Length < chars2.Length) ? chars1.Length : chars2.Length;

        for (int i = 0; i < smallerLength; i++)
        {
            if (chars1[i] > chars2[i]) {
                Console.WriteLine("chars1 > chars2 lexicographically");
                return;
            }
            else if (chars1[i] < chars2[i])
            {
                Console.WriteLine("chars1 < chars2 lexicographically");
                return;
            }
        }

        if (chars1.Length == chars2.Length)
        {
            Console.WriteLine("Arrays equal.");
            return;
        }
        else
        {
            if (smallerLength == chars1.Length) Console.WriteLine("chars1 < chars2 lexicographically");
            else Console.WriteLine("chars1 > chars2 lexicographically");
        }
    }
}
