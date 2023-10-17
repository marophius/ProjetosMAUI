using System.Reactive.Linq;

namespace MAUIGallery.Views.Components.Forms;

public partial class EntryPage : ContentPage
{
	public EntryPage()
	{
		InitializeComponent();

		IObservable<(string NewText, string OldText)> textChangedObservable = Observable
			.FromEventPattern<TextChangedEventArgs>(
			handler => EntryTest.TextChanged += handler,
			handler => EntryTest.TextChanged -= handler
			).Select(args => (args.EventArgs.NewTextValue, args.EventArgs.OldTextValue))
			.Throttle(TimeSpan.FromSeconds(6))
			.DistinctUntilChanged();


		_ = textChangedObservable.ObserveOn(SynchronizationContext.Current).Subscribe(value =>
		{
			EntryTest.Dispatcher.Dispatch(() =>
			{
				LblText.Text = $"Antigo: {value.OldText} - Novo: {value.NewText}";
			});
		});
	}

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
		LblText.Text = $"Antigo {e.OldTextValue} - Novo: {e.NewTextValue}";
    }
}