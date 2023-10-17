using MAUIGallery.Views.Lists.Models;
using System.Collections.ObjectModel;
using System.Text;

namespace MAUIGallery.Views.Lists;

public partial class CollectionViewPage : ContentPage
{
	public ObservableCollection<Movie> Movies = new ObservableCollection<Movie>();
	public int CountMovies = 0;
	public CollectionViewPage()
	{
		InitializeComponent();

		AddTenMovies();
		CollectionViewControl.ItemsSource = MovieList.GetGroupList();
	}

    private async void RefreshView_Refreshing(object sender, EventArgs e)
    {
		var refreshView = (RefreshView)sender;
		refreshView.IsRefreshing = true;

		await Task.Delay(3000);

		CollectionViewControl.ItemsSource = MovieList.GetList();

        refreshView.IsRefreshing = false;
    }

    private void CollectionViewControl_RemainingItemsThresholdReached(object sender, EventArgs e)
    {
		AddTenMovies();
    }

	private void AddTenMovies()
	{
		for(int i = 0; i < 10; i++)
		{
			Movie movie = new Movie
			{
				Id = CountMovies++,
				Name = $"Movie {CountMovies}",
				Description = $"Description {CountMovies}",
				LaunchYear = 2022,
				Duration = new TimeSpan(2, 0, 0)
			};
			Movies.Add(movie);
		}
	}

    private void CollectionViewControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		StringBuilder sb = new StringBuilder();
		foreach(Movie item in e.CurrentSelection)
		{
			sb.Append(item.Name + " - ");
		}

		LblSelectedMovies.Text = sb.ToString();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
		var group = (List<GroupMovie>)CollectionViewControl.ItemsSource;
		var item = group[2][0];
		CollectionViewControl.ScrollTo(item, position: ScrollToPosition.Start);
    }

    private void CollectionViewControl_Scrolled(object sender, ItemsViewScrolledEventArgs e)
    {
		LblScrollStatus.Text = $"Posicionamento: {e.VerticalOffset} - Espaçamento: {e.VerticalDelta} ";
		
    }
}