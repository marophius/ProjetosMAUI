using CommunityToolkit.Maui.Views;

namespace MAUIGallery.Views.CommunityToolkit.Popups;

public partial class MyPopup : Popup
{
	public MyPopup()
	{
		InitializeComponent();
	}

    private void ClosePopUp(object sender, EventArgs e)
    {
		this.Close();
    }
}