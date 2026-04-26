using DurakGame;
using System.Threading.Tasks;
namespace K
{
    public partial class Durak : Form
    {
        private Game game;
        private Card selectedCard = null;
        private Card selectedTableCard = null;
        public Durak()
        {
            InitializeComponent();

            // Шрифт
            Font cardFont = new Font("Segoe UI", 20, FontStyle.Bold);
            firstPlayerHand.Font = cardFont;
            firstComputerHand.Font = cardFont;
            firstTable.Font = cardFont;

            game = new Game();
            firstComputerHand.Enabled = false;
        }

        private void Durak_Load(object sender, EventArgs e)
        {
        }

        //Новая игра
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            btnAttack.Enabled = true;
            btnDefend.Enabled = true;
            btnTake.Enabled = true;
            btnFinish.Enabled = true;

            game.StartNewGame();
            selectedCard = null;
            selectedTableCard = null;
            UpdateUI();

            if (game.Attacker == game.Player2)
            {
                ComputerTurn();
            }
        }
        //Обновление формы
        private void UpdateUI()
        {
            firstPlayerHand.Items.Clear();
            firstComputerHand.Items.Clear();
            firstTable.Items.Clear();
            List<Card> playerCards = game.Player1.GetHand();

            for (int i = 0; i < playerCards.Count; i++)
            {
                firstPlayerHand.Items.Add(playerCards[i].ToShortString());
            }

            for (int i = 0; i < game.Player2.CardCount(); i++)
            {
                firstComputerHand.Items.Add("🂠");
            }

            List<Card> table = game.GetTableCards();

            for (int i = 0; i < table.Count; i++)
            {
                firstTable.Items.Add(table[i].ToShortString());
            }

            lblTrump.Text = "Козырь: " + game.TrumpSuit;
            lblDeck.Text = "В колоде: " + game.DeckCount() + " карт";

            //  Определяем кто атакует 
            if (game.Attacker == game.Player1)
            {
                lblTurn.Text = "Ходит: Игрок";
            }
            else
            {
                lblTurn.Text = "Ходит: Компьютер";
            }
        }
        //Выбор карты
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
                this.Text = "Выбрана " + selectedCard.ToShortString();
            }
        }
        //Выбор со стола
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
                this.Text = "Выбрана " + selectedTableCard.ToShortString();
            }
        }

        private void lblDeck_Click(object sender, EventArgs e)
        {

        }
        //Ход игрока
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
                    DisableGameButtons();
                    MessageBox.Show(winner == game.Player1 ? "Вы выиграли!" : "Победил компьютер!");
                }
                else ComputerTurn();
            }
            else
            {
                MessageBox.Show("Этой картой нельзя сейчас ходить!");
                return;
            }
        }
        //Действие компьютера
        private void ComputerTurn()
        {
            Player winner = game.CheckWinner();
            if (winner != null) return;
            if (game.Attacker == game.Player2)
                ComputerAttack();
            else if (game.Defender == game.Player2)
                ComputerDefend();
        }
        //Защита
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
            //Проверка на непокрытую карту
            List<Card> tbl = game.GetTableCards();
            Card notbeat = tbl[tbl.Count - 1];
            if (selectedTableCard != notbeat)
            {
                MessageBox.Show("Нужно бить последнюю непокрытую карту!");
                return;
            }
            bool res = game.Defend(game.Defender, selectedTableCard, selectedCard);
            if (res == false)
            {
                MessageBox.Show("Этой картой нельзя побить");

                //Перерисовываем стол, чтобы карты не испарялись
                firstTable.Items.Clear();
                List<Card> table = game.GetTableCards();
                for (int i = 0; i < table.Count; i++)
                {
                    firstTable.Items.Add(table[i].ToShortString());
                }

                return;
            }
            else
            {
                selectedCard = null;
                selectedTableCard = null;
                Player winner = game.CheckWinner();
                if (winner != null)
                {
                    DisableGameButtons();
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
        //Берем карты
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
                DisableGameButtons();
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
        //Бито
        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (game.Player1 != game.Attacker)
            {
                MessageBox.Show("Вы не можете завершить раунд, вы защищаетесь");
                return;
            }
            if (game.GetTableCards().Count == 0)
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
                DisableGameButtons();
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
        private async void ComputerAttack()
        {
            Card card = ComputerGetAttackCard();
            if (card != null)
            {
                game.MakeMove(game.Player2, card);
                UpdateUI();              
                // Проверка победителя после защиты
                Player winner = game.CheckWinner();
                if (winner != null)
                {
                    DisableGameButtons();
                    MessageBox.Show(winner == game.Player1 ? "Победил игрок!" : "Победил компьютер!");
                    return;
                }
            }
            else
            {
                game.FinishRound();
                UpdateUI();

                Player winner = game.CheckWinner();
                if (winner != null)
                {
                    DisableGameButtons();
                    MessageBox.Show(winner == game.Player1 ? "Победил игрок!" : "Победил компьютер!");
                    return;
                }
                if (game.Attacker == game.Player2)
                {
                    ComputerAttack();
                }
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
        private async Task Pause()
        {
            await Task.Delay(1800);
        }
        private async void ComputerDefend()
        {
            Card notbeatCard = null;
            List<Card> table = game.GetTableCards();
            if (table.Count == 0) return;
            if (table.Count % 2 == 0) return;//Карты лежат парами, отбивать нечего
            else
            {
                notbeatCard = table[table.Count - 1];
            }
            List<Card> hand = game.Player2.GetHand();
            List<Card> canbeat = new List<Card>();
            for (int i = 0; i < hand.Count; i++)
            {
                if (hand[i].CanBeat(notbeatCard, game.TrumpSuit)) canbeat.Add(hand[i]);
            }
            if (canbeat.Count > 0)
            {
                game.Defend(game.Player2, notbeatCard, canbeat[0]);
                UpdateUI();
                // Проверка победителя после защиты
                Player winner = game.CheckWinner();
                if (winner != null)
                {
                    DisableGameButtons();
                    MessageBox.Show(winner == game.Player1 ? "Победил игрок!" : "Победил компьютер!");
                    return;
                }
                ComputerDefend();
            }
            else
            {
                game.TakeCards(game.Player2);
                UpdateUI();

                Player winner = game.CheckWinner();
                if (winner != null)
                {
                    DisableGameButtons();
                    MessageBox.Show(winner == game.Player1 ? "Победил игрок!" : "Победил компьютер!");
                    return;
                }
            }
        }
        private void firstComputerHand_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private async Task ThinkPause()
        {
            await Task.Delay(100); // 0.1 секунда
        }
        private void ColorDrawItem(object sender, DrawItemEventArgs e)
        {
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void DisableGameButtons()
        {
            btnAttack.Enabled = false;
            btnDefend.Enabled = false;
            btnTake.Enabled = false;
            btnFinish.Enabled = false;
        }
    }
}
