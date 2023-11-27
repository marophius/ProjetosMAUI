using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace MAUIGallery.Views.CommunityToolkit;

public partial class AlertsPage : ContentPage
{
	public AlertsPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		// Config Visual
		var options = new SnackbarOptions
		{
			BackgroundColor = Colors.White,
			TextColor = Colors.Green
		};

		// Criaçao do objeto
		var snackbar = Snackbar.Make("Ocorreu um erro inesperado!", null, "OK", TimeSpan.FromSeconds(5), options);
		// Apresentação do snack
		snackbar.Show();
    }

    private void ShowToast(object sender, EventArgs e)
    {
		var toast = Toast.Make("Ocorreu um erro inesperado!", ToastDuration.Long, 18);
		toast.Show();
    }
}