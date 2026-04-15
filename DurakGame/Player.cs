using System;
using System.Collections.Generic;

namespace DurakGame
{
    public class Player
    {
        private List<Card> hand;
        public Player()
        {
            hand = new List<Card>();
        }
        public void AddCard(Card card)
        {
            hand.Add(card);
        }
        public void AddCards(List<Card> cards, int count)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                hand.Add(cards[i]);
            }
        }
        public void RemoveCard(Card card)
        {
            hand.Remove(card);
        }
        public List<Card> GetHand()
        {
            return hand;
        }
        public int CardCount()
        {
            return hand.Count;
        }
        public bool HasCard(Card card)
        {
            for (int i = 0;i < hand.Count;i++)
            {
                if (hand[i] == card) return true; 
            }
            return false;
        }
        public void ClearHand()
        {
            hand.Clear();
        }
    }
}
