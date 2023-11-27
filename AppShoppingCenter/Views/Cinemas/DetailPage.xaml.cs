namespace AppShoppingCenter.Views.Cinemas;

public partial class DetailPage : ContentPage
{
	private bool firstTime = false;
	public DetailPage()
	{
		InitializeComponent();
	}

    private void PlayPause(object sender, EventArgs e)
    {
		var btn = (ImageButton)sender;
		if (!firstTime)
		{
			var mediaWidthHalf = player.Width / 2 - btn.Width + 10;
			var mediaHeightHalf = player.Height / 2 - btn.Height - 20;
			Btn_playpause.TranslateTo(-mediaWidthHalf, mediaHeightHalf, 500);

			firstTime = true;
			MovieText.TranslateTo(0, 40);
		}
		if(player.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Playing)
		{
			
			player.Pause();
			Btn_playpause.Source = ImageSource.FromFile("play.png");
			SemanticProperties.SetHint(Btn_playpause, "Botão de Play do Trailer.");
        }
        else
		{
			player.Play();
            Btn_playpause.Source = ImageSource.FromFile("pause.png");
            SemanticProperties.SetHint(Btn_playpause, "Botão de Pause do Trailer.");
        }
    }
}