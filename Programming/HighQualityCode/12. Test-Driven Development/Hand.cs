using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Hand : IHand
    {
        private IList<ICard> cards;

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public IList<ICard> Cards 
        {
            get { return this.cards; }
            private set
            {
                if (value == null || value.Count != 5 || value.Contains(null))
                    throw new ArgumentException("Invalid cards count.");

                this.cards = value;
            } 
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var card in this.Cards)
                builder.AppendFormat("{0} ", card.ToString());

            builder.Remove(builder.Length - 1, 1);
            return builder.ToString();
        }
    }
}
