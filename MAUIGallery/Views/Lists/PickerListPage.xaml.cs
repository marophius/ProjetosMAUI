using MAUIGallery.Views.Lists.Models;

namespace MAUIGallery.Views.Lists;

public partial class PickerListPage : ContentPage
{
	public PickerListPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		var list = MovieList.GetList();
		PickerControl.ItemsSource = list;
		PickerControl.SelectedIndex = 3;

		var item = (Movie)PickerControl.SelectedItem;
    }
}