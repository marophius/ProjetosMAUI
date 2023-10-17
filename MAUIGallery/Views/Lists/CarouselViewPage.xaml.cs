using MAUIGallery.Views.Lists.Models;

namespace MAUIGallery.Views.Lists;

public partial class CarouselViewPage : ContentPage
{
	public CarouselViewPage()
	{
		InitializeComponent();
		CarouselViewControl.ItemsSource = MovieList.GetList();
	}
}