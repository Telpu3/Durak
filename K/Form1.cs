using DurakGame;
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
            if (selectedCard==null)
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

        }
    }
}
