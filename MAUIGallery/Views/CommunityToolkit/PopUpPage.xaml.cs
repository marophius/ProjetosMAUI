using CommunityToolkit.Maui.Views;
using MAUIGallery.Views.CommunityToolkit.Popups;

namespace MAUIGallery.Views.CommunityToolkit;

public partial class PopUpPage : ContentPage
{
	public PopUpPage()
	{
		InitializeComponent();
	}

    private void OpenPopUp(object sender, EventArgs e)
    {
		var popup = new MyPopup();
		this.ShowPopup(popup);
    }
}