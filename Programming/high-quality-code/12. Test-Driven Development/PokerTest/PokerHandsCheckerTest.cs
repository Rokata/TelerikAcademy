using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using System.Collections.Generic;

namespace PokerTest
{
    [TestClass]
    public class PokerHandsCheckerTest
    {
        /* Valid hands tests */

        [TestMethod]
        public void IsValidHand_FalseWhenTwoCardsAreSame()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Four, CardSuit.Spades));
            cards.Add(new Card(CardFace.Nine, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));

            IHand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();
            bool result = checker.IsValidHand(hand);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void IsValidHand_TrueWhenDifferent()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Four, CardSuit.Spades));
            cards.Add(new Card(CardFace.Nine, CardSuit.Spades));
            cards.Add(new Card(CardFace.Eight, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));

            IHand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();
            bool result = checker.IsValidHand(hand);

            Assert.AreEqual(true, result);
        }

        /* Flush tests */

        [TestMethod]
        public void IsFlush_ReturnsTrueOnFiveOfASuit()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Four, CardSuit.Spades));
            cards.Add(new Card(CardFace.Nine, CardSuit.Spades));
            cards.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cards.Add(new Card(CardFace.King, CardSuit.Spades));

            IHand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();
            bool isFlush = checker.IsFlush(hand);
            Assert.AreEqual(true, isFlush);
        }

        [TestMethod]
        public void IsFlush_ReturnsFalseOnTwoSuits()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Four, CardSuit.Spades));
            cards.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cards.Add(new Card(CardFace.King, CardSuit.Spades));

            IHand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();
            bool isFlush = checker.IsFlush(hand);
            Assert.AreEqual(false, isFlush);
        }

        [TestMethod]
        public void IsFlush_ReturnsFalseOnStraightFlush()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Queen, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ten, CardSuit.Clubs));
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));

            IHand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();
            bool isFlush = checker.IsFlush(hand);
            Assert.AreEqual(false, isFlush);
        }

        /* Four of a kind tests */

        [TestMethod]
        public void IsFourOfAKind_ReturnsTrueOnFourAces()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));

            IHand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();
            bool isFourOfAKind = checker.IsFourOfAKind(hand);
            Assert.AreEqual(true, isFourOfAKind);
        }

        [TestMethod]
        public void IsFourOfAKind_ReturnsFalseOnFullHouse()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));

            IHand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();
            bool isFourOfAKind = checker.IsFourOfAKind(hand);
            Assert.AreEqual(false, isFourOfAKind);
        }

        /* One pair tests */

        [TestMethod]
        public void IsOnePair_ReturnsTrueOnPairOfAces()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));

            IHand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();
            bool isOnePair = checker.IsOnePair(hand);
            Assert.AreEqual(true, isOnePair);
        }

        [TestMethod]
        public void IsOnePair_ReturnsFalseOnTwoPairs()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));

            IHand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();
            bool isOnePair = checker.IsOnePair(hand);
            Assert.AreEqual(false, isOnePair);
        }

        [TestMethod]
        public void IsOnePair_ReturnsFalseOnThreeOfAKind()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Nine, CardSuit.Spades));
            cards.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Nine, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));

            IHand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();
            bool isOnePair = checker.IsOnePair(hand);
            Assert.AreEqual(false, isOnePair);
        }

        [TestMethod]
        public void IsOnePair_ReturnsFalseOnFourOfAKind()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Nine, CardSuit.Spades));
            cards.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Nine, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Nine, CardSuit.Hearts));

            IHand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();
            bool isOnePair = checker.IsOnePair(hand);
            Assert.AreEqual(false, isOnePair);
        }

        [TestMethod]
        public void IsOnePair_ReturnsFalseOnFullHouse()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Nine, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Nine, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ten, CardSuit.Hearts));

            IHand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();
            bool isOnePair = checker.IsOnePair(hand);
            Assert.AreEqual(false, isOnePair);
        }

        [TestMethod]
        public void IsOnePair_ReturnsFalseOnHighCard()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Eight, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Seven, CardSuit.Diamonds));

            IHand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();
            bool isOnePair = checker.IsOnePair(hand);
            Assert.AreEqual(false, isOnePair);
        }

        [TestMethod]
        public void IsOnePair_ReturnsFalseOnStraight()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));
            cards.Add(new Card(CardFace.Six, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Eight, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Seven, CardSuit.Diamonds));

            IHand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();
            bool isOnePair = checker.IsOnePair(hand);
            Assert.AreEqual(false, isOnePair);
        }

        [TestMethod]
        public void IsOnePair_ReturnsFalseOnStraightFlush()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.King, CardSuit.Spades));
            cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Queen, CardSuit.Diamonds));

            IHand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();
            bool isOnePair = checker.IsOnePair(hand);
            Assert.AreEqual(false, isOnePair);
        }

        /* Two pair tests */

        [TestMethod]
        public void IsTwoPair_ReturnsFalseOnThreeOfAKind()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));
            cards.Add(new Card(CardFace.Queen, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Queen, CardSuit.Diamonds));

            IHand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();
            bool isTwoPair = checker.IsTwoPair(hand);
            Assert.AreEqual(false, isTwoPair);
        }

        [TestMethod]
        public void IsTwoPair_ReturnsFalseOnOnePair()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Queen, CardSuit.Diamonds));

            IHand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();
            bool isTwoPair = checker.IsTwoPair(hand);
            Assert.AreEqual(false, isTwoPair);
        }

        [TestMethod]
        public void IsTwoPair_ReturnsFalseOnFullHouse()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));

            IHand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();
            bool isTwoPair = checker.IsTwoPair(hand);
            Assert.AreEqual(false, isTwoPair);
        }

        [TestMethod]
        public void IsTwoPair_ReturnsFalseOnFourOfAKind()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Five, CardSuit.Clubs));

            IHand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();
            bool isTwoPair = checker.IsTwoPair(hand);
            Assert.AreEqual(false, isTwoPair);
        }

        /* Straight flush tests */

        [TestMethod]
        public void IsStraightFlush_ReturnsTrueOnRoyal()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.King, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Jack, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ten, CardSuit.Spades));
            cards.Add(new Card(CardFace.Queen, CardSuit.Spades));

            IHand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();
            bool isStraightFlush = checker.IsStraightFlush(hand);
            Assert.AreEqual(true, isStraightFlush);
        }

        [TestMethod]
        public void IsStraightFlush_ReturnsTrueOnSteelWheel()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));
            cards.Add(new Card(CardFace.Four, CardSuit.Spades));
            cards.Add(new Card(CardFace.Three, CardSuit.Spades));
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));

            IHand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();
            bool isStraightFlush = checker.IsStraightFlush(hand);
            Assert.AreEqual(true, isStraightFlush);
        }

        [TestMethod]
        public void IsStraightFlush_ReturnsFalseOnStraight()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ten, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Seven, CardSuit.Spades));
            cards.Add(new Card(CardFace.Nine, CardSuit.Spades));
            cards.Add(new Card(CardFace.Six, CardSuit.Spades));

            IHand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();
            bool isStraightFlush = checker.IsStraightFlush(hand);
            Assert.AreEqual(false, isStraightFlush);
        }

        [TestMethod]
        public void IsStraightFlush_ReturnsFalseOnFullHouse()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ten, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ten, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ten, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));

            IHand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();
            bool isStraightFlush = checker.IsStraightFlush(hand);
            Assert.AreEqual(false, isStraightFlush);
        }

        /* Straight tests */

        [TestMethod]
        public void IsStraight_ReturnsFalseOnStraightFlush()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ten, CardSuit.Spades));
            cards.Add(new Card(CardFace.Jack, CardSuit.Spades));
            cards.Add(new Card(CardFace.Queen, CardSuit.Spades));
            cards.Add(new Card(CardFace.King, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));

            IHand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();
            bool isStraight = checker.IsStraight(hand);
            Assert.AreEqual(false, isStraight);
        }

        [TestMethod]
        public void IsStraight_ReturnsTrueOnSteelWheel()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Three, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Four, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));

            IHand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();
            bool isStraight = checker.IsStraight(hand);
            Assert.AreEqual(true, isStraight);
        }

        /* High card tests */

        [TestMethod]
        public void IsHighCard_ReturnsTrueOnValidCase()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.King, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ten, CardSuit.Spades));
            cards.Add(new Card(CardFace.Seven, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Six, CardSuit.Spades));

            IHand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();
            bool isHighCard = checker.IsHighCard(hand);
            Assert.AreEqual(true, isHighCard);
        }

        [TestMethod]
        public void IsHighCard_ReturnsFalseOnFlush()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.Four, CardSuit.Spades));
            cards.Add(new Card(CardFace.Seven, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Three, CardSuit.Spades));

            IHand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();
            bool isHighCard = checker.IsHighCard(hand);
            Assert.AreEqual(false, isHighCard);
        }

        [TestMethod]
        public void IsHighCard_ReturnsFalseOnStraight()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.Four, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Three, CardSuit.Spades));
            cards.Add(new Card(CardFace.Six, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));

            IHand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();
            bool isHighCard = checker.IsHighCard(hand);
            Assert.AreEqual(false, isHighCard);
        }
    }
}
