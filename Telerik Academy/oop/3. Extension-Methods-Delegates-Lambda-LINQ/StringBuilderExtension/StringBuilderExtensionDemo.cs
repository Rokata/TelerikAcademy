using System;
using System.Text;

namespace StringBuilderExtension
{
    class StringBuilderDemo
    {
        static void Main()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("some text goes here");

            Console.WriteLine(sb.Substring(5, 4)); // "text"
            Console.WriteLine(sb.Substring(10, sb.Length - 10)); // "goes here"
        }
    }
}