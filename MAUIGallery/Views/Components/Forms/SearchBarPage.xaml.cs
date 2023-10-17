using System.Reactive.Linq;

namespace MAUIGallery.Views.Components.Forms;

public partial class SearchBarPage : ContentPage
{
	private IDisposable _searchBarSubscription;
	public SearchBarPage()
	{
		InitializeComponent();
		CreateSearchBarObservable();
	}

	private void CreateSearchBarObservable()
	{
		_searchBarSubscription = Observable.FromEventPattern<EventHandler, EventArgs>(
			handler => SearchBarTest.SearchButtonPressed += handler,
			handler => SearchBarTest.SearchButtonPressed -= handler
			).Subscribe(val =>
			{
				SearchBarTest.Dispatcher.Dispatch(() =>
				{
                    LblValue.Text = $"Palavra-chave para pesquisar: {SearchBarTest.Text}";
                });
				
			});
	}

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
		_searchBarSubscription?.Dispose();
    }
}