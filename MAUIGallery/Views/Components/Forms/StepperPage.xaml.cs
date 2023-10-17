using System.Reactive.Linq;

namespace MAUIGallery.Views.Components.Forms;

public partial class StepperPage : ContentPage
{
	public StepperPage()
	{
		InitializeComponent();

		IObservable<(double oldValue, double newValue)> stepperValueChangeObservable = Observable.FromEventPattern<ValueChangedEventArgs>(
			handler => StepperTest.ValueChanged += handler,
			handler => StepperTest.ValueChanged -= handler
			).Select(args => (args.EventArgs.OldValue, args.EventArgs.NewValue))
			.DistinctUntilChanged();

		_ = stepperValueChangeObservable.Subscribe(
			val =>
			{
				LblValue.Text = $"Antigo: {val.oldValue} - Novo: {val.newValue}";
			},
			ex =>
			{
				DisplayAlert("Error",$"{ex.Message}", "Ok");
			}
		);
	}
}