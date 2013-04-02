using System;

class FloatToBinary
{
    public static void Main()
    {
        Console.Write("Enter float: ");
        float number = float.Parse(Console.ReadLine());

        byte[] byteArray = BitConverter.GetBytes(number);

        Array.Reverse(byteArray);
        string result = BitConverter.ToString(byteArray).ToLower();

        Console.WriteLine(result);

        string binaryPresentation = string.Empty;

        foreach (char c in result)
        {
            switch (c)
            {
                case '0':
                    binaryPresentation += "0000";
                    break;
                case '1':
                    binaryPresentation += "0001";
                    break;
                case '2':
                    binaryPresentation += "0010";
                    break;
                case '3':
                    binaryPresentation += "0011";
                    break;
                case '4':
                    binaryPresentation += "0100";
                    break;
                case '5':
                    binaryPresentation += "0101";
                    break;
                case '6':
                    binaryPresentation += "0110";
                    break;
                case '7':
                    binaryPresentation += "0111";
                    break;
                case '8':
                    binaryPresentation += "1000";
                    break;
                case '9':
                    binaryPresentation += "1001";
                    break;
                case 'a':
                    binaryPresentation += "1010";
                    break;
                case 'b':
                    binaryPresentation += "1011";
                    break;
                case 'c':
                    binaryPresentation += "1100";
                    break;
                case 'd':
                    binaryPresentation += "1101";
                    break;
                case 'e':
                    binaryPresentation += "1110";
                    break;
                case 'f':
                    binaryPresentation += "1111";
                    break;
            }
        }

        Console.Write("Result: ");
        for (int i = 0; i < binaryPresentation.Length; i++)
        {
            Console.Write(binaryPresentation[i]);
            if (i == 0 || i == 8)  Console.Write(" ");
        }
    }
}