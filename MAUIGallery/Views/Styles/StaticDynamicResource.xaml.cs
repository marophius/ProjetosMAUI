namespace MAUIGallery.Views.Styles;

public partial class StaticDynamicResource : ContentPage
{
	public StaticDynamicResource()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Resources["TitleColor"] = Colors.Green;
    }
}