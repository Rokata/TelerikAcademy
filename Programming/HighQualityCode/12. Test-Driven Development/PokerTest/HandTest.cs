using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using System.Collections.Generic;

namespace PokerTest
{
    [TestClass]
    public class HandTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid cards count")]
        public void Cards_ThrowsExceptionOnInvalidCount()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ten, CardSuit.Spades));

            IHand hand = new Hand(cards);
        }
    }
}
