using AppMVVM.ViewModels;

namespace AppMVVM.Views;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();
		BindingContext = new StartPageViewModel();
	}
}