namespace MAUIGallery.Views.Animations;

public partial class BasicAnimation : ContentPage
{
	public BasicAnimation()
	{
		InitializeComponent();
	}

    private async void Diminuir(object sender, EventArgs e)
    {
        await Image.ScaleTo(0.5, 2000);
    }

    private async void Aumentar(object sender, EventArgs e)
    {
        await Image.ScaleTo(2, 2000);
    }

    private void Normal(object sender, EventArgs e)
    {
        Image.Scale = 1;
        Image.TranslationX = 0;
        Image.TranslationY = 0;
        Image.Rotation = 0;
        Image.RotationX = 0;
        Image.RotationY = 0;
    }

    private void Mover(object sender, EventArgs e)
    {
        Image.TranslateTo(100, 0, 2000, Easing.BounceOut);
    }

    private async void Rotacao(object sender, EventArgs e)
    {
        await Image.RotateTo(360, 2000);
        await Image.RelRotateTo(90, 1000);
        Image.Rotation = 0;
    }

    private async void FadeTo(object sender, EventArgs e)
    {
        await Image.FadeTo(0.3, 1000);
    }

    private async void Sequencial(object sender, EventArgs e)
    {
        await Image.TranslateTo(100, 0, 250);
        await Image.TranslateTo(-100, 0, 250);
        await Image.TranslateTo(0, 0, 250);
    }

    private async void Paralelo(object sender, EventArgs e)
    {
        var task1 = Image.TranslateTo(100, 0, 4000);
        var task2 = Image.RotateTo(720, 4000);
        var task3 = Image.TranslateTo(0, 0, 4000);
        await Task.WhenAll(task1, task2, task3);
    }

    private void Cancelamento(object sender, EventArgs e)
    {
        Image.CancelAnimations();
    }

    private void Custom(object sender, EventArgs e)
    {
        var principal = new Animation();
        var animacao01 = new Animation(a => Image.TranslationX = a, 0, 150, Easing.Linear, null);
        var animacao02 = new Animation(a => Image.Rotation = a, 0, 360, Easing.Linear, null);
        principal.Add(0, 0.5, animacao01);
        principal.Add(0.5, 1, animacao02);

        principal.Commit(this, "AnimacaoPersonalizada", 16, 10000, null, null, null);
        //animacao01.Commit(this, "MoverORobo", 16, 1000, null, null, () => true);
    }
}