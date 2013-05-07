using System;
using System.Text;

namespace Poker
{
    public class Card : ICard
    {
        private CardFace face;
        private CardSuit suit;

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public CardFace Face 
        {
            get { return this.face; }
            private set
            {
                int faceValue = (int)value;

                if (faceValue < 2 || faceValue > 14)
                    throw new ArgumentException("No matching face was found for the specified value.");

                this.face = value;
            } 
        }

        public CardSuit Suit
        {
            get { return this.suit; }
            private set
            {
                int suitValue = (int)value;

                if (suitValue < 1 || suitValue > 4)
                    throw new ArgumentException("No matching suit was found for the specified value.");

                this.suit = value;
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("{0}{1}", GetFacePresentation(), GetSuitSymbol());
            return builder.ToString();
        }

        private char GetSuitSymbol()
        {
            switch (this.Suit)
            {
                case CardSuit.Clubs:
                    return '♣';
                case CardSuit.Diamonds:
                    return '♦';
                case CardSuit.Hearts:
                    return '♥';
                case CardSuit.Spades:
                    return '♠';
                default:
                    throw new InvalidOperationException("No matching card suit was found.");
            }
        }

        private string GetFacePresentation()
        {
            int cardValue = (int) this.Face;

            if (cardValue >= 2 && cardValue <= 10)
                return cardValue.ToString();

            switch (this.Face)
            {
                case CardFace.Jack:
                    return "J";
                case CardFace.Queen:
                    return "Q";
                case CardFace.King:
                    return "K";
                case CardFace.Ace:
                    return "A";
                default: throw new InvalidOperationException("No matching card face was found.");
            }
        }

        public override bool Equals(object obj)
        {
            Card otherCard = obj as Card;

            if (otherCard == null)
                return false;

            return (this.Face == otherCard.Face && this.Suit == otherCard.Suit);
        }

    }
}
