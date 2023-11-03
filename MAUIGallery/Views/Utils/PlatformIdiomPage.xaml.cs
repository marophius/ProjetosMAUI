namespace MAUIGallery.Views.Utils;

public partial class PlatformIdiomPage : ContentPage
{
	public PlatformIdiomPage()
	{
		InitializeComponent();

		if(Device.RuntimePlatform == Device.WinUI)
		{
			DisplayAlert("Windows", "Esta mensagem é exclusiva do windows", "ok");
		}
		if(Device.Idiom == TargetIdiom.Desktop)
		{
            DisplayAlert("Desktop", "Esta mensagem é exclusiva do Desktop/PC", "ok");
        }
		
	}
}