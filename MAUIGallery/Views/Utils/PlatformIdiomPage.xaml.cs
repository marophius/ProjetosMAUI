namespace MAUIGallery.Views.Utils;

public partial class PlatformIdiomPage : ContentPage
{
	public PlatformIdiomPage()
	{
		InitializeComponent();

		if(Device.RuntimePlatform == Device.WinUI)
		{
			DisplayAlert("Windows", "Esta mensagem � exclusiva do windows", "ok");
		}
		if(Device.Idiom == TargetIdiom.Desktop)
		{
            DisplayAlert("Desktop", "Esta mensagem � exclusiva do Desktop/PC", "ok");
        }
		
	}
}