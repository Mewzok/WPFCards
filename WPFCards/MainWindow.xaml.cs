using System.Windows;

namespace WPFCards {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private Deck deck;

        public MainWindow() {
            InitializeComponent(); // this builds the window, must be first

            deck = new Deck();
            UpdateStatus("Unshuffled deck created.");
        }

        private void Reset_Click(object sender, RoutedEventArgs e) {
            deck.Reset();
            CardArea.Children.Clear();
            UpdateStatus("Deck reset to new unshuffled state.");
        }

        private void Shuffle_Click(object sender, RoutedEventArgs e) {
            deck.Shuffle();
            UpdateStatus("Deck shuffled.");
        }

        private void UpdateStatus(string message) {
            StatusText.Text = message;
        }

        private void Draw_Click(object sender, RoutedEventArgs e) {
            // check for valid number input
            if(!int.TryParse(DrawNumberField.Text, out int num) || num < 0) {
                num = 0;
            }

            var drawn = deck.Draw(num);
            CardArea.Children.Clear();

            // add cards to the UI
            foreach (var card in drawn) {
                var viewModel = new CardViewModel(card);
                var control = new CardControl { DataContext = viewModel };
                CardArea.Children.Add(control);
            }

            UpdateStatus($"Drew {drawn.Count} cards. Remaining: {deck.getCardCount()}.");
        }
    }
}