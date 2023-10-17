

using MAUIGallery.Libraries.Fix;

namespace MAUIGallery;

public partial class AppFlyout : FlyoutPage
{
	public AppFlyout()
	{
		InitializeComponent();
	}

    private void FlyoutPage_IsPresentedChanged(object sender, EventArgs e)
    {
		KeyboardFix.HideKeyboard();
    }
}