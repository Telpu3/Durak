using System;
using System.Collections.Generic;

namespace DurakGame
{
    public class Deck
    {
        private List<Card> cards;
        private Random random;

        public Deck()
        {
            cards = new List<Card>();
            random = new Random();
            Create36Cards();
        }
        private void Create36Cards()
        {
            string[] suits = new string[] { "Черви", "Буби", "Крести", "Пики" };
            int[] ranks = new int[] { 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            cards.Clear();
            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < ranks.Length; j++)
                {
                    Card card = new Card(suits[i], ranks[j]);
                    cards.Add(card);
                }
            }
        }
        public void Shuffle()
        {
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Card temp = cards[k];
                cards[k] = cards[n];
                cards[n] = temp;
            }
        }

        public Card Drawcard()
        {
            if (cards.Count == 0) return null;

            Card topcard = cards[cards.Count - 1];
            cards.RemoveAt(cards.Count - 1);
            return topcard;
        }
        public List<Card> DrawCards(int count)
        {
            List<Card> drawncards = new List<Card>();
            for (int i = 0; i < count; i++)
            {
                Card card = Drawcard();
                if (card != null) drawncards.Add(card);
            }
            return drawncards;
        }
        public Card PeekCard()
        {
            if (cards.Count == 0) return null;
            return cards[cards.Count - 1];
        }
        public int Count()
        {
            return cards.Count;
        }
    }
}
