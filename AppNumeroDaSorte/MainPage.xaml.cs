namespace AppNumeroDaSorte;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnGenerateLuckyNumbers(object sender, EventArgs args)
	{
		await NameApp.TranslateTo(-300, 0, 250);
        await NameApp.FadeTo(0, 1000);
        NameApp.IsVisible = false;
        var set = GenerateLuckNumbers();

        LuckyNumber01.Text = set.ElementAt(0).ToString("D2");
        LuckyNumber02.Text = set.ElementAt(1).ToString("D2");
        LuckyNumber03.Text = set.ElementAt(2).ToString("D2");
        LuckyNumber04.Text = set.ElementAt(3).ToString("D2");
        LuckyNumber05.Text = set.ElementAt(4).ToString("D2");
        LuckyNumber06.Text = set.ElementAt(5).ToString("D2");
        //await ContainerLuckyNumbers.FadeTo(1, 250);
        ContainerLuckyNumbers.TranslationX = this.Width;
        ContainerLuckyNumbers.IsVisible = true;
        await Task.WhenAll(ContainerLuckyNumbers.FadeTo(1, 250), ContainerLuckyNumbers.TranslateTo(0, 0, 250));
        
		
		

    }

    private SortedSet<int> GenerateLuckNumbers()
	{
		var list = new SortedSet<int>();
		while (list.Count < 6) 
		{
            var random = new Random();
            var luckyNumber = random.Next(1, 60);
			list.Add(luckyNumber);
        }

		return list;
	}
}