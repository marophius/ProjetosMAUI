using System.Reactive.Linq;

namespace MAUIGallery.Views.Components.Forms;

public partial class SwitchPage : ContentPage
{
	public SwitchPage()
	{
		InitializeComponent();

		var toggleEventObservable = Observable
			.FromEventPattern<ToggledEventArgs>(
			handler => SwitchTest.Toggled += handler,
			handler => SwitchTest.Toggled -= handler
			).Select(args => args.EventArgs.Value);

		_ = toggleEventObservable.Subscribe(
			val =>
			{
				LblStatus.IsVisible = val;
				LblStatus.Text = $"Marcado: {val}";
			});
	}
}