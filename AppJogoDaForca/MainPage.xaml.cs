using AppJogoDaForca.Libraries.Text;
using AppJogoDaForca.Models;
using AppJogoDaForca.Repositories;

namespace AppJogoDaForca
{
    public partial class MainPage : ContentPage
    {
        private Word _word;
        private int _errors = 0;
        public MainPage()
        {
            InitializeComponent();
            ResetScreen();
        }


        private async void OnButtonClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.IsEnabled = false;
            string letter = button.Text;
            var positions = _word.Text.AllIndexesOf(letter);

            if (positions.Count == 0)
            {
                ErrorHandler(button);
                await IsGameOver();
                return;
            }

            ReplaceLetter(letter, positions);
            button.Style = App.Current.Resources.MergedDictionaries.ElementAt(1)["Success"] as Style;
            HasWinner();
        }

        private void ReplaceLetter(string letter, List<int> positions)
        {
            foreach (var position in positions)
            {
                LblText.Text = LblText.Text.Remove(position, 1).Insert(position, letter);

            }
        }

        private void ErrorHandler(Button button)
        {
            _errors++;
            ImageForca.Source = ImageSource.FromFile($"forca{_errors + 1}.png");
            button.Style = App.Current.Resources.MergedDictionaries.ElementAt(1)["Error"] as Style;
        }

        private async Task IsGameOver()
        {
            if (_errors == 6)
            {
                await DisplayAlert("Perdeu!", "Você foi enforcado, quer começar um novo jogo ?", "Novo jogo");
                ResetScreen();
            }
        }

        private void ResetScreen()
        {
            ResetVirtualKeyboard();
            _errors = 0;
            ImageForca.Source = ImageSource.FromFile("forca1.png");
            var repository = new WordRepository();
            _word = repository.GetRandomWord();

            LblTips.Text = _word.Tips;
            LblText.Text = new string('_', _word.Text.Length);
            
        }

        private async void HasWinner()
        {
            if(!LblText.Text.Contains("_"))
            {
                await DisplayAlert("Você venceu!", "Você conseguiu acahar todas as letras!", "Novo Jogo");
                ResetScreen();
            }
        }

        private void ResetVirtualKeyboard()
        {

            foreach(var child in KeyboardContainer.Children )
            {
                if(child is HorizontalStackLayout h)
                {
                    ResetVirtualLines(h);
                }
            }
        }

        private void ResetVirtualLines(HorizontalStackLayout h)
        {
            foreach(Button button in h.Children)
            {
                button.IsEnabled = true;
                button.Style = null;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ResetScreen();
        }
    }
}