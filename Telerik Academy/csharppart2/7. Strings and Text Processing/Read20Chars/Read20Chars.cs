using System;

class Read20Chars
{
    static void Main()
    {
        try
        {
            Console.Write("Enter word not more than 20 chars long: ");
            string input = Console.ReadLine();

            if (input.Length > 20) throw new IndexOutOfRangeException();
            else Console.WriteLine(input += new string('*', 20 - input.Length));
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("String too long!");
        }
    }
}
