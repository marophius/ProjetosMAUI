using MAUIGallery.Repositories;

namespace MAUIGallery.Views;

public partial class Menu : ContentPage
{
    private readonly IGroupComponentRepository _repository;
	public Menu()
	{
		InitializeComponent();

		_repository = new GroupComponentRepository();
        MenuCollection.ItemsSource = _repository.GetGroupComponents();
	}

	private void OnTapComponent(object sender, TappedEventArgs e)
	{
		
		var page = (Type)e.Parameter;

		((FlyoutPage)App.Current.MainPage).Detail = new NavigationPage((Page)Activator.CreateInstance(page));
		((FlyoutPage)App.Current.MainPage).IsPresented = false;

    }

    private void OnInicioTap(object sender, TappedEventArgs e)
    {
        ((FlyoutPage)App.Current.MainPage).Detail = new NavigationPage(new MainPage());
        ((FlyoutPage)App.Current.MainPage).IsPresented = false;
    }

    private void OnExtraTap(object sender, TappedEventArgs e)
    {
        ((FlyoutPage)App.Current.MainPage).Detail = new NavigationPage(new MainPage());
        ((FlyoutPage)App.Current.MainPage).IsPresented = false;
    }

    private void OnCreditsTap(object sender, TappedEventArgs e)
    {
        ((FlyoutPage)App.Current.MainPage).Detail = new NavigationPage(new MainPage());
        ((FlyoutPage)App.Current.MainPage).IsPresented = false;
    }
}