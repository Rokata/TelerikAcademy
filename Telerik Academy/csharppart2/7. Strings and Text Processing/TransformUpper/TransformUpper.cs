using System;

class TransformUpper
{
    static void Main()
    {
        string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
        char[] textArray = text.ToCharArray();
        int index = 0;

        while ((index = text.IndexOf("<upcase>", index)) != -1)
        {
            index += 8;

            while (textArray[index] != '<')
            {
                textArray[index] = Char.ToUpper(textArray[index]);
                index++;
            }
        }

        text = new string(textArray);
        text = text.Replace("<upcase>", "").Replace("</upcase>", "");

        Console.WriteLine(text);
    }
}