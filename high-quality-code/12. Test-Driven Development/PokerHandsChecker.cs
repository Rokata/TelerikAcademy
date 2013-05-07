using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        private HandType GetHandType(IHand hand)
        {
            HandType handType;

            if (IsHighCard(hand))
                handType = HandType.HighCard;
            else if (IsOnePair(hand))
                handType = HandType.OnePair;
            else if (IsTwoPair(hand))
                handType = HandType.TwoPair;
            else if (IsThreeOfAKind(hand))
                handType = HandType.ThreeOfAKind;
            else if (IsStraight(hand))
                handType = HandType.Straight;
            else if (IsFlush(hand))
                handType = HandType.Flush;
            else if (IsFullHouse(hand))
                handType = HandType.FullHouse;
            else if (IsFourOfAKind(hand))
                handType = HandType.FourOfAKind;
            else
                handType = HandType.StraightFlush;

            return handType;
        }
        
        public bool IsValidHand(IHand hand)
        {
            if (hand == null || hand.Cards.Count != 5)
                return false;

            int handCount = hand.Cards.Count;

            // check for repeating cards 
            for (int i = 0; i < handCount - 1; i++)
                for (int j = i + 1; j < handCount; j++)
                {
                    if (hand.Cards[i].Equals(hand.Cards[j]))
                        return false;
                }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            if (!IsValidHand(hand))
                return false;

            int distinctSuits = hand.Cards.Select(x => x.Suit).Distinct().Count();
            if (distinctSuits > 1) return false; // all cards must be of the same suit

            var faces = hand.Cards.Select(x => x.Face).OrderBy(x => x).ToList<CardFace>();

            if (IsSteelWheel(faces))
                return true;

            for (int i = 1; i < faces.Count; i++)
            {
                if (faces[i] - faces[i-1] != 1) // current's rank must be exactly 1 higher than previous
                    return false;
            }

            return true;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!IsValidHand(hand))
                return false;

            var faces = hand.Cards.Select(x => x.Face).OrderBy(x => x).ToList<CardFace>();

            // * * * * # or # * * * * 
            bool isFourOfAKind = (faces[0] == faces[1] && faces[1] == faces[2] && faces[2] == faces[3]) ||
                                 (faces[1] == faces[2] && faces[2] == faces[3] && faces[3] == faces[4]);

            return isFourOfAKind;
        }

        public bool IsFullHouse(IHand hand)
        {
            if (!IsValidHand(hand))
                return false;

            var faces = hand.Cards.Select(x => x.Face).OrderBy(x => x).ToList<CardFace>();
 
            // [a a a b b] or [b b a a a]
            bool isFullHouse = (faces[0] == faces[1] && faces[1] == faces[2] && faces[3] == faces[4]) ||
                               (faces[0] == faces[1] && faces[2] == faces[3] && faces[3] == faces[4]);

            return isFullHouse;                         
        }

        public bool IsFlush(IHand hand)
        {
            if (!IsValidHand(hand) || IsStraightFlush(hand))
                return false;

            return hand.Cards.Count(x => (x.Suit == hand.Cards[0].Suit)) == 5; // 5 non-sequential of the same suit
        }

        public bool IsStraight(IHand hand)
        {
            if (!IsValidHand(hand) || IsStraightFlush(hand))
                return false;

            var faces = hand.Cards.Select(x => x.Face).OrderBy(x => x).ToList<CardFace>();

            if (IsSteelWheel(faces))
                return true;

            for (int i = 1; i < faces.Count; i++)
            {
                if (faces[i] - faces[i-1] != 1)
                    return false;
            }

            return true;
        }

        private bool IsSteelWheel(IList<CardFace> faces)
        {
            // ensure it is in ascending order as some methods count on descending one
            faces = faces.OrderBy(x => x).ToList<CardFace>(); 

            return faces[0] == CardFace.Two &&
                   faces[1] == CardFace.Three &&
                   faces[2] == CardFace.Four &&
                   faces[3] == CardFace.Five &&
                   faces[4] == CardFace.Ace;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if (!IsValidHand(hand) || IsFourOfAKind(hand) || IsFullHouse(hand))
                return false;

            var faces = hand.Cards.Select(x => x.Face).OrderBy(x => x).ToList<CardFace>();

            // [* * * a b], [a * * * b] or [a b * * * ]
            bool isThreeOfAKind = (faces[0] == faces[1] && faces[1] == faces[2]) ||
                                  (faces[1] == faces[2] && faces[2] == faces[3]) ||
                                  (faces[2] == faces[3] && faces[3] == faces[4]);
            return isThreeOfAKind;
        }

        public bool IsTwoPair(IHand hand)
        {
            if (!IsValidHand(hand))
                return false;

            if (IsFourOfAKind(hand) || IsFullHouse(hand))
                return false;

            // sorting decreases possible positioning of eventual pairs
            var faces = hand.Cards.Select(x => x.Face).OrderBy(x => x).ToList<CardFace>();

            // [a a b b c], [a a c b b] or [c a a b b] 
            bool isTwoPair = (faces[0] == faces[1] && faces[2] == faces[3]) ||
                             (faces[0] == faces[1] && faces[3] == faces[4]) ||
                             (faces[1] == faces[2] && faces[3] == faces[4]);
            return isTwoPair;
        }

        public bool IsOnePair(IHand hand)
        {
            if (!IsValidHand(hand))
                return false;

            List<CardFace> faces = hand.Cards.Select(x => x.Face).ToList<CardFace>();
            int distinct = faces.Distinct().Count(); // must be exactly 4 for one pair

            return distinct == 4;
        }

        public bool IsHighCard(IHand hand)
        {
            if (!IsValidHand(hand) || IsStraight(hand))
                return false;

            int distinctFaces = hand.Cards.Select(x => x.Face).Distinct().Count();
            int distinctSuits = hand.Cards.Select(x => x.Suit).Distinct().Count();

            return (distinctFaces == 5 && distinctSuits > 1);
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            if (firstHand == null || secondHand == null || !IsValidHand(firstHand) ||
                !IsValidHand(secondHand))
                throw new ArgumentException("Invalid hand value.");

            var firstHandType = GetHandType(firstHand);
            var secondHandType = GetHandType(secondHand);
            
            int result = CompareHands(firstHand, secondHand, firstHandType, secondHandType);

            return result;
        }

        private int CompareHands(IHand firstHand, IHand secondHand, HandType firstHandType, HandType secondHandType)
        {
            if (firstHandType > secondHandType)
                return 1;
            if (firstHandType < secondHandType)
                return -1;

            var firstHandFaces = OrderHandWithoutRepeat(firstHand);
            var secondHandFaces = OrderHandWithoutRepeat(secondHand);

            if (firstHandType == HandType.Straight || firstHandType == HandType.StraightFlush)
            {
                if (IsSteelWheel(firstHandFaces) && !IsSteelWheel(secondHandFaces))
                    return -1;
                else if (!IsSteelWheel(firstHandFaces) && IsSteelWheel(secondHandFaces))
                    return 1;
                else
                    return 0;
            }

            for (int i = 0; i < firstHandFaces.Count; i++)
            {
                if (firstHandFaces[i] != secondHandFaces[i])
                    return firstHandFaces[i] > secondHandFaces[i] ? 1 : -1;
            }

            return 0;
        }

        private IList<CardFace> OrderHandWithoutRepeat(IHand hand)
        {
            var faces = hand.Cards.GroupBy(x => x.Face).OrderByDescending(x => x.Count())
                .ThenByDescending(x => x.Key).Select(x => x.Key).ToList<CardFace>();

            return faces;
        }
    }
}
