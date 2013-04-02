using System;
using System.Collections;

class CheckBrackets
{
    static void Main()
    {
        Console.Write("Enter expression: ");
        string expression = Console.ReadLine();
        Stack brackets = new Stack();

        foreach (char ch in expression)
        {
            if (ch == '(') brackets.Push(ch);
            if (ch == ')')
            {
                if (brackets.Count > 0)
                {
                    brackets.Pop();
                }
                else
                {
                    Console.WriteLine("Incorrectly put brackets.");
                    return;
                }
            }
        }

        if (brackets.Count == 0) Console.WriteLine("Brackets are put correctly.");
        else Console.WriteLine("Incorrectly put brackets.");
    }
}
