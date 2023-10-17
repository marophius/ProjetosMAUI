using MAUIGallery.Views.Lists.Models;

namespace MAUIGallery.Views.Lists;

public partial class DataTemplateSelectorPage : ContentPage
{
	public DataTemplateSelectorPage()
	{
		InitializeComponent();

		CollectionViewControl.ItemsSource = MovieList.GetList();
	}
}