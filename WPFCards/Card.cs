namespace WPFCards
{
    public class Card
    {
        public enum Suit
        {
            Clubs,
            Diamonds,
            Hearts,
            Spades
        }
        public enum Rank {
            Two = 2,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King,
            Ace
        }

        public Suit CardSuit { get; set; }

        public Rank CardRank { get; set; }

        public Card(Suit suit, Rank rank)
        {
            CardSuit = suit;
            CardRank = rank;
        }
        public override string ToString()
        {
            return $"{CardRank} of {CardSuit}";
        }
    }
}
