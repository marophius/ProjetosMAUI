namespace MAUIGallery.Views.Styles;

public partial class VisualStateManagerPage : ContentPage
{
	public VisualStateManagerPage()
	{
		InitializeComponent();
	}

    private void OnTappedChangeVisualState(object sender, TappedEventArgs e)
    {
		var labl = (Label)sender;
		VisualStateManager.GoToState(labl, "Tapped");
    }
}