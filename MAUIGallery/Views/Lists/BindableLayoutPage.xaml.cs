using MAUIGallery.Views.Lists.Models;

namespace MAUIGallery.Views.Lists;

public partial class BindableLayoutPage : ContentPage
{
	public BindableLayoutPage()
	{
		InitializeComponent();
		var list = MovieList.GetList();
		var layout = VerticalStackLayoutControl;

		BindableLayout.SetItemsSource(layout, list);
	}
}