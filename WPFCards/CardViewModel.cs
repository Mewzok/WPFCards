using System.Windows.Media;

namespace WPFCards {
    public class CardViewModel {
        private Card card;

        public string TopText { get; }
        public string BottomText { get; }
        public string SuitSymbol { get; }

        public CardViewModel(Card card) {
            this.card = card;

            TopText = card.CardRank.ToString();
            BottomText = card.CardRank.ToString();

            SuitSymbol = card.CardSuit switch {
                Card.Suit.Clubs => "♣",
                Card.Suit.Diamonds => "♦",
                Card.Suit.Hearts => "♥",
                Card.Suit.Spades => "♠",
                _ => "?"
            };
        }

        public Brush SuitColor {
            get {
                return card.CardSuit == Card.Suit.Hearts || card.CardSuit == Card.Suit.Diamonds ? Brushes.Red : Brushes.Black;
            }
        }
    }
}
