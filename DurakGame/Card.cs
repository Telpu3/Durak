namespace DurakGame
{
    public class Card
    {
        public string Suit { get; private set; }//Масть

        public int Rank { get; private set; }//Ранг карты

        public string Name {  get; private set; }//Полное название карты

        public Card(string suit, int rank)
        {
            Suit= suit;
            Rank= rank;
            Name = GetRankName(rank) + " " + suit;
        }
        private string GetRankName(int rank)
        {
            if (rank == 6) return "6";
            if (rank == 7) return "7";
            if (rank == 8) return "8";
            if (rank == 9) return "9";
            if (rank == 10) return "10";
            if (rank == 11) return "Валет";
            if (rank == 12) return "Дама";
            if (rank == 13) return "Король";
            if (rank == 14) return "Туз";
            return rank.ToString();
        }
        //Определяет, может ли одна карта побить другую
        public bool CanBeat(Card othercard, string trumpSuit)
        {
            if (this.Suit == othercard.Suit)
            {
                if (this.Rank > othercard.Rank) return true;
                else return false;
            }
            if (this.Suit == trumpSuit) return true;
            return false;
        }
        public string ToShortString()
        {
            string rankStr = Rank switch
            {
                6 => "6",
                7 => "7",
                8 => "8",
                9 => "9",
                10 => "10",
                11 => "В",
                12 => "Д",
                13 => "К",
                14 => "Т",
                _ => Rank.ToString()
            };

            string suitSymbol = Suit switch
            {
                "Черви" => "♥️",
                "Буби" => "♦️",
                "Крести" => "♣️",
                "Пики" => "♠️",
                _ => Suit
            };

            return rankStr + " " + suitSymbol;
        }
    }
}
