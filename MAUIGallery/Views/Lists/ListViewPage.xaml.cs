using MAUIGallery.Views.Lists.Models;
using System.Reactive.Linq;

namespace MAUIGallery.Views.Lists;

public partial class ListViewPage : ContentPage
{
    private IDisposable _selectedItemChanged;
	public ListViewPage()
	{
		InitializeComponent();

        CreateItemSelectedEventObservable();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        ListViewControl.ItemsSource = MovieList.GetGroupList();
    }

    private void CreateItemSelectedEventObservable()
    {
        _selectedItemChanged = Observable
                                        .FromEventPattern<SelectedItemChangedEventArgs>(
                                            handler => ListViewControl.ItemSelected += handler,
                                            handler => ListViewControl.ItemSelected -= handler)
                                        .Select(e => e.EventArgs)
                                        .Subscribe(value =>
                                        {
                                            var movie = value.SelectedItem as Movie;
                                            App.Current.MainPage.DisplayAlert("Filme selecionado!", $"O filme selecionado é: {movie.Name}", "OK");
                                        });
    }

    protected override void OnDisappearing()
    {
        _selectedItemChanged?.Dispose();
        base.OnDisappearing();
    }

    private async void ListViewControl_Refreshing(object sender, EventArgs e)
    {
        ListViewControl.IsRefreshing = true;
        await Task.Delay(3000);
        ListViewControl.ItemsSource = MovieList.GetGroupList();
    }
}