using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerTest
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid card suit")]
        public void CardSuit_ThrowsExceptionOnInvalidIntValue()
        {
            Card c = new Card(CardFace.Five, (CardSuit)50);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid card face")]
        public void CardFace_ThrowsExceptionOnInvalidIntValue()
        {
            Card c = new Card((CardFace)20, CardSuit.Hearts);
        }

        [TestMethod]
        public void ToString_ExpectedFiveClubs()
        {
            Card c = new Card(CardFace.Five, CardSuit.Clubs);
            string output = c.ToString();
            Assert.AreEqual("5♣", output);
        }
    }
}
