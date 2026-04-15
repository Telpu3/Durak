using System;
using System.Collections.Generic;

namespace DurakGame
{
    public class Game
    {
        private Deck deck;
        private Card trumpCard;
        private List <Card> tableCards;
        private List<Card> discardPile;
        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }
        public Player Attacker { get; private set; }
        public Player Defender {  get; private set; }
        public string TrumpSuit {  get; private set; }

        public Game()
        {
            Player1 = new Player();
            Player2 = new Player();
            deck= new Deck();
            tableCards = new List<Card>();
            discardPile = new List<Card>();
        }
        public void StartNewGame()
        {
            Player1.ClearHand();
            Player2.ClearHand();

            tableCards.Clear();
            discardPile.Clear();
            
            deck=new Deck();
            deck.Shuffle();

            trumpCard = deck.PeekCard();
            TrumpSuit = trumpCard.Suit;

            Player1.AddCards(deck.DrawCards(6));
            Player2.AddCards(deck.DrawCards(6));

            DetermineFirstAttacker();
        }
        private void DetermineFirstAttacker()
        {
            List<Card> hand1 = Player1.GetHand();
            List<Card> hand2 = Player2.GetHand();
            Card lowestTrump1 = null;
            Card lowestTrump2 = null;
            for (int i = 0; i < hand1.Count; i++)
            {
                if (hand1[i].Suit==TrumpSuit)
                {
                    if (lowestTrump1 == null || hand1[i].Rank<lowestTrump1.Rank) lowestTrump1=hand1[i];
                }
            }
            for (int i = 0; i < hand2.Count; i++)
            {
                if (hand2[i].Suit == TrumpSuit)
                {
                    if (lowestTrump2 == null || hand2[i].Rank < lowestTrump2.Rank) lowestTrump2 = hand2[i];
                }
            }
            if (lowestTrump1 == null && lowestTrump2 == null)
            {
                Random rnd = new Random();
                if (rnd.Next(2) == 0)
                {
                    Attacker = Player1;
                    Defender = Player2;
                }
                else
                {
                    Attacker = Player2;
                    Defender = Player1;
                }
            }
            // Если у Player1 нет козыря - ходит Player2
            else if (lowestTrump1 == null)
            {
                Attacker = Player2;
                Defender = Player1;
            }
            // Если у Player2 нет козыря - ходит Player1
            else if (lowestTrump2 == null)
            {
                Attacker = Player1;
                Defender = Player2;
            }
            // Если у обоих есть козыри - ходит тот у кого младше
            else if (lowestTrump1.Rank < lowestTrump2.Rank)
            {
                Attacker = Player1;
                Defender = Player2;
            }
            else
            {
                Attacker = Player2;
                Defender = Player1;
            }
        }
        private void MakeMove(Player player, Card card)
        {

        }
    }
}
