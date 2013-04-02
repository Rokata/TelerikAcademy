using System;

class CharToUnicode
{
    static void Main()
    {
        string str = "Hi!";
        foreach (char c in str)
        {
            int ch = (int)c;
            Console.Write("\\u{0:X4}", ch); 
        }
    }
}
