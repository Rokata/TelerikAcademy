using System;

class HexademicalToDecimal
{
    static void Main()
    {
        Console.Write("Enter a number in hexademical numeral system: ");
        char[] hexArray = Console.ReadLine().ToUpper().ToCharArray();
        int dec = 0;

        Array.Reverse(hexArray);

        for (int i = 0; i < hexArray.Length; i++)
        {
            int intValue = 0;

            if (hexArray[i] >= 'A' && hexArray[i] <= 'F')
            {
                switch (hexArray[i])
                {
                    case 'A': intValue = 10; break;
                    case 'B': intValue = 11; break;
                    case 'C': intValue = 12; break;
                    case 'D': intValue = 13; break;
                    case 'E': intValue = 14; break;
                    case 'F': intValue = 15; break;
                }
            }
            else
            {
                intValue = int.Parse(hexArray[i].ToString());
            }

            if (intValue != 0)
            {
                for (int j = 0; j < i; j++)
                {
                    intValue *= 16;
                }
            }

            dec += intValue;
        }

        Console.WriteLine("Hexademical presentation: {0}", dec);
    }
}
