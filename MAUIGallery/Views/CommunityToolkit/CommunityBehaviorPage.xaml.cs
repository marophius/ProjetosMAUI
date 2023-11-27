using MAUIGallery.Views.CommunityToolkit.ViewModels;

namespace MAUIGallery.Views.CommunityToolkit;

public partial class CommunityBehaviorPage : ContentPage
{
	public CommunityBehaviorPage()
	{
		InitializeComponent();
	}

    private void OnPressed(object sender, EventArgs e)
    {
		var vm = (CommunityBehaviorPageViewModel)BindingContext;
		if (vm.PressedCommand.CanExecute(null))
		{
			vm.PressedCommand.Execute(null);
		}
    }
}