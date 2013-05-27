using System;

class CardsInDeckCombinations
{
    static void Main()
    {
        string cardName = "";

        for (int i = 1; i <= 4; i++)
        {
            for (int j = 2; j <= 14; j++)
            {
                switch (j)
                {
                    case 2: cardName += "Two of "; break;
                    case 3: cardName += "Three of "; break;
                    case 4: cardName += "Four of "; break;
                    case 5: cardName += "Five of "; break;
                    case 6: cardName += "Six of "; break;
                    case 7: cardName += "Seven of "; break;
                    case 8: cardName += "Eight of "; break;
                    case 9: cardName += "Nine of "; break;
                    case 10: cardName += "Ten of "; break;
                    case 11: cardName += "Jack of "; break;
                    case 12: cardName += "Queen of "; break;
                    case 13: cardName += "King of "; break;
                    case 14: cardName += "King of "; break;
                }

                switch (i)
                {
                    case 1: cardName += "spades"; break;
                    case 2: cardName += "hearts"; break;
                    case 3: cardName += "diamonds"; break;
                    case 4: cardName += "clubs"; break;
                }

                Console.WriteLine(cardName);
                cardName = "";
            }

            Console.WriteLine();
        }

    }
}
