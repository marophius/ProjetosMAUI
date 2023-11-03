using MAUIGallery.Resources.Styles;

namespace MAUIGallery.Views.Styles;

public partial class Theme : ContentPage
{
	private bool Light = true;
	public Theme()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		var dictionaries = Application.Current.Resources.MergedDictionaries;

		if(dictionaries is not null)
		{
			dictionaries.Remove(dictionaries.ElementAt(2));
			if (Light)
			{
				dictionaries.Add(new DarkTheme());
			}else
			{
				dictionaries.Add(new LightTheme());
			}
			Light = !Light;
		}
    }
}