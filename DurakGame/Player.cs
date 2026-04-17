using System;
using System.Collections.Generic;

namespace DurakGame
{
    public class Player
    {
        private List<Card> hand;//Карты в руке игрока
        public Player()
        {
            hand = new List<Card>();
        }
        public void AddCard(Card card)//Добавление карты в руку
        {
            hand.Add(card);
        }
        public void AddCards(List<Card> cards)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                hand.Add(cards[i]);
            }
        }
        public void RemoveCard(Card card)//Удаление карты из руки
        {
            hand.Remove(card);
        }
        public List<Card> GetHand()
        {
            return hand;
        }
        public int CardCount()//Возвращает кол-во карт в руке
        {
            return hand.Count;
        }
        public bool HasCard(Card card)//Определяет, есть ли карта в руке 
        {
            for (int i = 0;i < hand.Count;i++)
            {
                if (hand[i] == card) return true; 
            }
            return false;
        }
        public void ClearHand()//Очистка карт в руке
        {
            hand.Clear();
        }
    }
}
