using DurakGame;
using System.Threading.Tasks;
namespace K
{
    public partial class Form1 : Form
    {
        private Game game;
        private Card selectedCard = null;
        private Card selectedTableCard = null;
        public Form1()
        {
            InitializeComponent();
            game = new Game();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            game.StartNewGame();
            selectedCard = null;
            selectedTableCard = null;
            UpdateUI();

            if (game.Attacker == game.Player2)
            {
                ComputerTurn();
            }
        }
        private void UpdateUI()
        {
            firstPlayerHand.Items.Clear();
            firstComputerHand.Items.Clear();
            firstTable.Items.Clear();
            List<Card> playerCards = game.Player1.GetHand();

            for (int i = 0; i < playerCards.Count; i++)
            {
                firstPlayerHand.Items.Add(playerCards[i].Name);
            }

            for (int i = 0; i < game.Player2.CardCount(); i++)
            {
                firstComputerHand.Items.Add("🂠 Карта");
            }

            List<Card> table = game.GetTableCards();

            for (int i = 0; i < table.Count; i++)
            {
                firstTable.Items.Add(table[i].Name);
            }

            lblTrump.Text = "Козырь: " + game.TrumpSuit;
            lblDeck.Text = "В колоде: " + game.DeckCount() + " карт";

            // 7. Определяем кто атакует и пишем в lblTurn
            if (game.Attacker == game.Player1)
            {
                lblTurn.Text = "Ходит: Игрок";
            }
            else
            {
                lblTurn.Text = "Ходит: Компьютер";
            }
        }

        private void firstPlayerHand_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = firstPlayerHand.SelectedIndex;
            if (index == -1)
            {
                selectedCard = null;
                return;
            }
            List<Card> playerCards = game.Player1.GetHand();
            if (index < playerCards.Count)
            {
                selectedCard = playerCards[index];
                this.Text = "Выбрана " + selectedCard.Name;
            }
        }
        private void firstTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = firstTable.SelectedIndex;
            if (index == -1)
            {
                selectedTableCard = null;
                return;
            }
            List<Card> tablecards = game.GetTableCards();
            if (index < tablecards.Count)
            {
                selectedTableCard = tablecards[index];
                this.Text = "Выбрана " + selectedTableCard.Name;
            }
        }

        private void lblDeck_Click(object sender, EventArgs e)
        {

        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            if (selectedCard == null)
            {
                MessageBox.Show("Сначала выберите карту!");
                return;
            }
            if (game.MakeMove(game.Player1, selectedCard))
            {
                selectedCard = null;
                UpdateUI();
                Player winner = game.CheckWinner();
                if (winner != null)
                {
                    if (winner == game.Player1) MessageBox.Show("Победил игрок!");
                    else MessageBox.Show("Победил компьютер!");
                }
                else ComputerTurn();

            }
            else
            {
                MessageBox.Show("Этой картой нельзя сейчас ходить!");
                return;
            }
        }
        private void ComputerTurn()
        {
            Player winner = game.CheckWinner();

            if (winner != null)
            {
                return;
            }
            if (game.Attacker == game.Player2) ComputerAttack();
            if (game.Defender == game.Player2) ComputerDefend();
            UpdateUI();
            winner = game.CheckWinner();
            if (winner != null)
            {
                if (winner == game.Player1) MessageBox.Show("Победил игрок!");
                else MessageBox.Show("Победил компьютер!");
            }
        }

        private void btnDefend_Click(object sender, EventArgs e)
        {
            if (game.Defender != game.Player1)
            {
                MessageBox.Show("Сейчас не Ваша очередь защищаться!");
                return;
            }
            if (selectedCard == null)
            {
                MessageBox.Show("Выберите карту для защиты!");
                return;
            }
            if (selectedTableCard == null)
            {
                MessageBox.Show("Выберите карту со стола, которую хотите побить!");
                return;
            }
            bool res = game.Defend(game.Defender, selectedTableCard, selectedCard);
            if (res == false)
            {
                MessageBox.Show("Этой картой нельзя побить");
                return;
            }
            else
            {
                selectedCard = null;
                selectedTableCard = null;
                Player winner = game.CheckWinner();
                if (winner != null)
                {
                    if (winner == game.Player1)
                    {
                        MessageBox.Show("Победил игрок!");
                    }
                    else
                    {
                        MessageBox.Show("Победил компьютер!");
                    }
                }
                else
                {
                    ComputerTurn();
                }
            }
        }

        private void btnTake_Click(object sender, EventArgs e)
        {
            if (game.Defender != game.Player1)
            {
                MessageBox.Show("Сейчас не Ваша очередь забирать");
                return;
            }
            if (game.GetTableCards().Count == 0)
            {
                MessageBox.Show("Забирать нечего(");
                return;
            }
            game.TakeCards(game.Player1);
            selectedCard = null;
            selectedTableCard = null;
            UpdateUI();
            Player winner = game.CheckWinner();
            if (winner != null)
            {
                if (winner == game.Player1)
                {
                    MessageBox.Show("Победил игрок!");
                }
                else
                {
                    MessageBox.Show("Победил компьютер!");
                }
            }
            else
            {
                ComputerTurn();
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (game.Player1!=game.Attacker)
            {
                MessageBox.Show("Вы не можете завершить раунд, вы защищаетесь");
                return;
            }
            if (game.GetTableCards().Count==0)
            {
                MessageBox.Show("Стол пустой!");
                return;
            }
            game.FinishRound();
            selectedTableCard = null;
            selectedCard = null;
            UpdateUI();

            Player winner = game.CheckWinner();
            if (winner != null)
            {
                if (winner == game.Player1)
                {
                    MessageBox.Show("Победил игрок!");
                }
                else
                {
                    MessageBox.Show("Победил компьютер!");
                }
            }
            else
            {
                ComputerTurn();
            }
        }
        private void ComputerAttack(int depth = 0)
        {
            if (depth > 6) return;
            Card card = ComputerGetAttackCard();
            if (card!=null)
            {
                game.MakeMove(game.Player2, card);
                UpdateUI();
                Pause();
                ComputerAttack(depth+1);
            }
            else
            {
                game.FinishRound();
                UpdateUI();
            }
        }
        private Card ComputerGetAttackCard()
        {
            List<Card> hand = game.Player2.GetHand();
            if (hand.Count == 0) return null;

            List<Card> table = game.GetTableCards();
            if (table.Count == 0)
            {
                Card minCard = hand[0];
                int trumps = 0;
                for (int i = 0; i < hand.Count; i++)
                {
                    if (hand[i].Suit == game.TrumpSuit) trumps++;
                    if (hand[i].Suit != game.TrumpSuit && hand[i].Rank < minCard.Rank)
                    {
                        minCard = hand[i];
                    }
                }
                if (trumps == game.Player2.CardCount())
                {
                    Card mintrump = hand[0];
                    for (int i = 0; i < hand.Count; i++)
                    {
                        if (hand[i].Rank < mintrump.Rank) mintrump = hand[i];
                    }
                    return mintrump;
                }
                else return minCard;
            }
            else
            {
                for (int i = 0; i < hand.Count; i++)
                {
                    for (int j = 0; j < table.Count; j++)
                    {
                        if (hand[i].Rank == table[j].Rank)
                        {
                            return hand[i];
                        }
                    }
                }
            }
            return null;
        }
        private async void Pause()
        {
            await Task.Delay(1000); // пауза 1 секунда
        }
        private void ComputerDefend(int depth = 0)
        {
            if (depth > 6) return;
            Card notbeatCard = null;
            List <Card> table = game.GetTableCards();
            if (table.Count == 0) return;
            if (table.Count % 2 == 0) return;//Карты лежат парами, отбивать нечего
            else
            {
                notbeatCard = table[table.Count - 1];

            }
            List<Card> hand = game.Player2.GetHand();
            List<Card> canbeat = null;
            for (int i=0; i<hand.Count; i++)
            {
                if (hand[i].CanBeat(notbeatCard, game.TrumpSuit)) canbeat.Add(hand[i]);
            }
            if (canbeat != null)
            {
                game.Defend(game.Player2, notbeatCard, canbeat[0]);
                Pause();
                UpdateUI();
                ComputerDefend(depth + 1);
            }
            else
            {
                game.TakeCards(game.Player2);//Отбить нечем - забираем карты
                UpdateUI();
                return;
            }
        }
    }
}
