using System;
using System.Collections.Generic;

namespace DurakGame
{
    public class Deck
    {
        private List<Card> cards;
        private Random random;

        public Deck()//Создание колоды
        {
            cards = new List<Card>();
            random = new Random();
            Create36Cards();
        }
        //Создание колоды из 36 карт
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
        //Перемешивание колоды(алгоритм Фишера-Йетса)
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
        //Метод берёт верхнюю карту из колоды и удаляет её оттуда
        public Card Drawcard()
        {
            if (cards.Count == 0) return null;

            Card topcard = cards[cards.Count - 1];
            cards.RemoveAt(cards.Count - 1);
            return topcard;
        }
        // Метод берёт сразу несколько карт из колоды
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
        // Метод позволяет посмотреть верхнюю карту колоды, НЕ удаляя её
        public Card PeekCard()
        {
            if (cards.Count == 0) return null;
            return cards[cards.Count - 1];
        }
        // Метод возвращает количество оставшихся карт в колоде 
        public int Count()
        {
            return cards.Count;
        }
    }
}
