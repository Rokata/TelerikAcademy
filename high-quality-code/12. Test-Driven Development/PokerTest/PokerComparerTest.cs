using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerTest
{
    [TestClass]
    public class PokerComparerTest
    {
        [TestMethod]
        public void CompareHands_ZeroOnEqualTwoPairHands()
        {
            IList<ICard> cardsFirstHand = new List<ICard>();
            cardsFirstHand.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cardsFirstHand.Add(new Card(CardFace.Four, CardSuit.Spades));
            cardsFirstHand.Add(new Card(CardFace.King, CardSuit.Spades));
            cardsFirstHand.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cardsFirstHand.Add(new Card(CardFace.King, CardSuit.Hearts));

            IHand firstHand = new Hand(cardsFirstHand);

            IList<ICard> cardsSecondHand = new List<ICard>();
            cardsSecondHand.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cardsSecondHand.Add(new Card(CardFace.Four, CardSuit.Hearts));
            cardsSecondHand.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cardsSecondHand.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cardsSecondHand.Add(new Card(CardFace.King, CardSuit.Clubs));

            IHand secondHand = new Hand(cardsSecondHand);

            PokerHandsChecker checker = new PokerHandsChecker();

            int result = checker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CompareHands_OneOnTwoPairsFirstWithHigherKicker()
        {
            IList<ICard> cardsFirstHand = new List<ICard>();
            cardsFirstHand.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cardsFirstHand.Add(new Card(CardFace.Four, CardSuit.Spades)); // kicker 1 (higher)
            cardsFirstHand.Add(new Card(CardFace.King, CardSuit.Spades));
            cardsFirstHand.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cardsFirstHand.Add(new Card(CardFace.King, CardSuit.Hearts));

            IHand firstHand = new Hand(cardsFirstHand);

            IList<ICard> cardsSecondHand = new List<ICard>();
            cardsSecondHand.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cardsSecondHand.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cardsSecondHand.Add(new Card(CardFace.King, CardSuit.Clubs));
            cardsSecondHand.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cardsSecondHand.Add(new Card(CardFace.Three, CardSuit.Hearts)); // kicker 2

            IHand secondHand = new Hand(cardsSecondHand);

            PokerHandsChecker checker = new PokerHandsChecker();

            int result = checker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void CompareHands_MinusOneOnSimilarThrees()
        {
            IList<ICard> cardsFirstHand = new List<ICard>();
            cardsFirstHand.Add(new Card(CardFace.Eight, CardSuit.Clubs)); // kicker 1
            cardsFirstHand.Add(new Card(CardFace.Four, CardSuit.Spades));
            cardsFirstHand.Add(new Card(CardFace.Four, CardSuit.Diamonds));
            cardsFirstHand.Add(new Card(CardFace.Four, CardSuit.Clubs));
            cardsFirstHand.Add(new Card(CardFace.Seven, CardSuit.Diamonds)); // kicker 2

            IHand firstHand = new Hand(cardsFirstHand);

            IList<ICard> cardsSecondHand = new List<ICard>();
            cardsSecondHand.Add(new Card(CardFace.Four, CardSuit.Diamonds));
            cardsSecondHand.Add(new Card(CardFace.Four, CardSuit.Spades));
            cardsSecondHand.Add(new Card(CardFace.Nine, CardSuit.Diamonds)); // kicker 1
            cardsSecondHand.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cardsSecondHand.Add(new Card(CardFace.Four, CardSuit.Clubs)); // kicker 2 

            IHand secondHand = new Hand(cardsSecondHand);

            PokerHandsChecker checker = new PokerHandsChecker();

            int result = checker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void CompareHands_ZeroOnFourOfAKinds()
        {
            IList<ICard> cardsFirstHand = new List<ICard>();
            cardsFirstHand.Add(new Card(CardFace.Eight, CardSuit.Clubs)); 
            cardsFirstHand.Add(new Card(CardFace.Four, CardSuit.Spades)); // kicker
            cardsFirstHand.Add(new Card(CardFace.Eight, CardSuit.Diamonds));
            cardsFirstHand.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cardsFirstHand.Add(new Card(CardFace.Eight, CardSuit.Hearts)); 

            IHand firstHand = new Hand(cardsFirstHand);

            IList<ICard> cardsSecondHand = new List<ICard>();
            cardsSecondHand.Add(new Card(CardFace.Eight, CardSuit.Diamonds));
            cardsSecondHand.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cardsSecondHand.Add(new Card(CardFace.Four, CardSuit.Diamonds)); // kicker
            cardsSecondHand.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            cardsSecondHand.Add(new Card(CardFace.Eight, CardSuit.Hearts));

            IHand secondHand = new Hand(cardsSecondHand);

            PokerHandsChecker checker = new PokerHandsChecker();

            int result = checker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CompareHands_ZeroOnTwoSteelWheels()
        {
            IList<ICard> cardsFirstHand = new List<ICard>();
            cardsFirstHand.Add(new Card(CardFace.Five, CardSuit.Clubs));
            cardsFirstHand.Add(new Card(CardFace.Ace, CardSuit.Spades)); 
            cardsFirstHand.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            cardsFirstHand.Add(new Card(CardFace.Four, CardSuit.Spades));
            cardsFirstHand.Add(new Card(CardFace.Three, CardSuit.Hearts));

            IHand firstHand = new Hand(cardsFirstHand);

            IList<ICard> cardsSecondHand = new List<ICard>();
            cardsSecondHand.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            cardsSecondHand.Add(new Card(CardFace.Five, CardSuit.Spades));
            cardsSecondHand.Add(new Card(CardFace.Ace, CardSuit.Diamonds)); 
            cardsSecondHand.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cardsSecondHand.Add(new Card(CardFace.Four, CardSuit.Hearts));

            IHand secondHand = new Hand(cardsSecondHand);

            PokerHandsChecker checker = new PokerHandsChecker();

            int result = checker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CompareHands_MinusOneOnSteelWheelAndHigherStraight()
        {
            IList<ICard> cardsFirstHand = new List<ICard>();
            cardsFirstHand.Add(new Card(CardFace.Five, CardSuit.Clubs));
            cardsFirstHand.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cardsFirstHand.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            cardsFirstHand.Add(new Card(CardFace.Four, CardSuit.Spades));
            cardsFirstHand.Add(new Card(CardFace.Three, CardSuit.Hearts));

            IHand firstHand = new Hand(cardsFirstHand);

            IList<ICard> cardsSecondHand = new List<ICard>();
            cardsSecondHand.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            cardsSecondHand.Add(new Card(CardFace.Five, CardSuit.Spades));
            cardsSecondHand.Add(new Card(CardFace.Four, CardSuit.Diamonds));
            cardsSecondHand.Add(new Card(CardFace.Three, CardSuit.Clubs));
            cardsSecondHand.Add(new Card(CardFace.Six, CardSuit.Hearts));

            IHand secondHand = new Hand(cardsSecondHand);

            PokerHandsChecker checker = new PokerHandsChecker();

            int result = checker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(-1, result);
        }
    }
}
