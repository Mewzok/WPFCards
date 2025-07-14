using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WPFCards
{
    public class Deck
    {
        private List<Card> cards;
        private Random rand = new Random();

        public Deck() {
            Reset();
        }

        public void Reset()
        {
            cards = new List<Card>();
            foreach (Card.Suit suit in Enum.GetValues(typeof(Card.Suit)))
            {
                foreach (Card.Rank rank in Enum.GetValues(typeof(Card.Rank)))
                {
                    cards.Add(new Card(suit, rank));
                }
            }
        }

        public void Shuffle()
        {
            for(int i = cards.Count - 1; i > 0; i--)
            {
                int j = RandomNumberGenerator.GetInt32(0, i + 1);
                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }

        public List<Card> Draw(int num) {
            if(num > cards.Count) {
                num = cards.Count;
            }

            var drawnCards = cards.Take(num).ToList();
            cards.RemoveRange(0, num);
            return drawnCards;
        }

        public int getCardCount() {
            return cards.Count;
        }
    }
}
