using Microsoft.VisualStudio.TestTools.UnitTesting;
using DurakGame;
using System.Collections.Generic;

namespace DurakGame.Tests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void CanBeat_SameSuit_HigherRank_ReturnsTrue()
        {
            // Arrange
            Card attacking = new Card("Черви", 7);
            Card defending = new Card("Черви", 10);
            string trump = "Буби";

            // Act
            bool result = defending.CanBeat(attacking, trump);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeat_SameSuit_LowerRank_ReturnsFalse()
        {
            Card attacking = new Card("Черви", 10);
            Card defending = new Card("Черви", 7);

            bool result = defending.CanBeat(attacking, "Буби");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CanBeat_DifferentSuit_Trump_ReturnsTrue()
        {
            Card attacking = new Card("Черви", 10);
            Card defending = new Card("Буби", 6);
            string trump = "Буби";

            bool result = defending.CanBeat(attacking, trump);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeat_DifferentSuit_NotTrump_ReturnsFalse()
        {
            Card attacking = new Card("Черви", 10);
            Card defending = new Card("Пики", 14);
            string trump = "Буби";

            bool result = defending.CanBeat(attacking, trump);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetRankName_ReturnsCorrectNames()
        {
            Assert.AreEqual("6 Черви", new Card("Черви", 6).Name);
            Assert.AreEqual("10 Буби", new Card("Буби", 10).Name);
            Assert.AreEqual("Валет Пики", new Card("Пики", 11).Name);
            Assert.AreEqual("Дама Крести", new Card("Крести", 12).Name);
            Assert.AreEqual("Король Черви", new Card("Черви", 13).Name);
            Assert.AreEqual("Туз Буби", new Card("Буби", 14).Name);
        }
    }

    [TestClass]
    public class DeckTests
    {
        [TestMethod]
        public void NewDeck_Has36Cards()
        {
            Deck deck = new Deck();
            Assert.AreEqual(36, deck.Count());
        }

        [TestMethod]
        public void DrawCard_ReducesCount_ReturnsCard()
        {
            Deck deck = new Deck();
            int initialCount = deck.Count();

            Card card = deck.Drawcard();

            Assert.IsNotNull(card);
            Assert.AreEqual(initialCount - 1, deck.Count());
        }

        [TestMethod]
        public void DrawCards_ReturnsCorrectAmount()
        {
            Deck deck = new Deck();

            List<Card> cards = deck.DrawCards(6);

            Assert.AreEqual(6, cards.Count);
            Assert.AreEqual(30, deck.Count());
        }

        [TestMethod]
        public void DrawCard_FromEmptyDeck_ReturnsNull()
        {
            Deck deck = new Deck();
            for (int i = 0; i < 36; i++) deck.Drawcard();

            Card card = deck.Drawcard();

            Assert.IsNull(card);
        }

        [TestMethod]
        public void PeekCard_DoesNotRemoveCard()
        {
            Deck deck = new Deck();
            int count = deck.Count();

            Card card = deck.PeekCard();

            Assert.IsNotNull(card);
            Assert.AreEqual(count, deck.Count());
        }
    }

    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void NewPlayer_HasEmptyHand()
        {
            Player player = new Player();
            Assert.AreEqual(0, player.CardCount());
        }

        [TestMethod]
        public void AddCard_IncreasesHandCount()
        {
            Player player = new Player();
            Card card = new Card("Черви", 7);

            player.AddCard(card);

            Assert.AreEqual(1, player.CardCount());
        }

        [TestMethod]
        public void AddCards_AddsMultipleCards()
        {
            Player player = new Player();
            List<Card> cards = new List<Card>
            {
                new Card("Черви", 6),
                new Card("Буби", 7),
                new Card("Пики", 8)
            };

            player.AddCards(cards);

            Assert.AreEqual(3, player.CardCount());
        }

        [TestMethod]
        public void RemoveCard_RemovesCorrectCard()
        {
            Player player = new Player();
            Card card1 = new Card("Черви", 7);
            Card card2 = new Card("Буби", 10);

            player.AddCard(card1);
            player.AddCard(card2);
            player.RemoveCard(card1);

            Assert.AreEqual(1, player.CardCount());
            Assert.IsFalse(player.HasCard(card1));
            Assert.IsTrue(player.HasCard(card2));
        }

        [TestMethod]
        public void HasCard_ReturnsTrueIfCardInHand()
        {
            Player player = new Player();
            Card card = new Card("Черви", 7);
            player.AddCard(card);

            Assert.IsTrue(player.HasCard(card));
        }

        [TestMethod]
        public void ClearHand_RemovesAllCards()
        {
            Player player = new Player();
            player.AddCard(new Card("Черви", 7));
            player.AddCard(new Card("Буби", 10));

            player.ClearHand();

            Assert.AreEqual(0, player.CardCount());
        }
    }

    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void NewGame_HasTwoPlayers()
        {
            Game game = new Game();

            Assert.IsNotNull(game.Player1);
            Assert.IsNotNull(game.Player2);
        }

        [TestMethod]
        public void StartNewGame_Deals6CardsToEachPlayer()
        {
            Game game = new Game();

            game.StartNewGame();

            Assert.AreEqual(6, game.Player1.CardCount());
            Assert.AreEqual(6, game.Player2.CardCount());
        }

        [TestMethod]
        public void StartNewGame_SetsTrumpSuit()
        {
            Game game = new Game();

            game.StartNewGame();

            Assert.IsNotNull(game.TrumpSuit);
            Assert.IsTrue(
                game.TrumpSuit == "Черви" ||
                game.TrumpSuit == "Буби" ||
                game.TrumpSuit == "Крести" ||
                game.TrumpSuit == "Пики"
            );
        }

        [TestMethod]
        public void StartNewGame_SetsAttackerAndDefender()
        {
            Game game = new Game();

            game.StartNewGame();

            Assert.IsNotNull(game.Attacker);
            Assert.IsNotNull(game.Defender);
            Assert.AreNotEqual(game.Attacker, game.Defender);
        }

        [TestMethod]
        public void MakeMove_WithEmptyTable_AllowsAnyCard()
        {
            Game game = new Game();
            game.StartNewGame();

            Player attacker = game.Attacker;
            Card card = attacker.GetHand()[0];

            bool result = game.MakeMove(attacker, card);

            Assert.IsTrue(result, "Атакующий должен мочь ходить любой картой на пустой стол");
            Assert.AreEqual(1, game.GetTableCards().Count);
        }

        [TestMethod]
        public void MakeMove_AsDefender_ReturnsFalse()
        {
            Game game = new Game();
            game.StartNewGame();

            Player defender = game.Defender;
            Card card = defender.GetHand()[0];

            bool result = game.MakeMove(defender, card);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckWinner_AtStart_ReturnsNull()
        {
            Game game = new Game();
            game.StartNewGame();

            Player winner = game.CheckWinner();

            Assert.IsNull(winner);
        }

        [TestMethod]
        public void TakeCards_MovesTableCardsToPlayer()
        {
            Game game = new Game();
            game.StartNewGame();

            Player attacker = game.Attacker;
            Player defender = game.Defender;

            Card card = attacker.GetHand()[0];
            game.MakeMove(attacker, card);

            int defenderCountBefore = defender.CardCount();
            int tableCount = game.GetTableCards().Count;

            game.TakeCards(defender);

            Assert.AreEqual(defenderCountBefore + tableCount, defender.CardCount());
            Assert.AreEqual(0, game.GetTableCards().Count);
        }

        [TestMethod]
        public void FinishRound_WithCardsOnTable_ClearsTableAndSwapsRoles()
        {
            Game game = new Game();
            game.StartNewGame();

            Player oldAttacker = game.Attacker;
            Player oldDefender = game.Defender;

            // Кладём карту на стол
            Card card = oldAttacker.GetHand()[0];
            game.MakeMove(oldAttacker, card);

            // Завершаем раунд
            game.FinishRound();

            Assert.AreEqual(0, game.GetTableCards().Count);
            Assert.AreEqual(oldDefender, game.Attacker);
            Assert.AreEqual(oldAttacker, game.Defender);
        }
    }
}