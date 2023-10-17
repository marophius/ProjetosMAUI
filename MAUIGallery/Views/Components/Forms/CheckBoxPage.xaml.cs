using System.Reactive.Linq;
namespace MAUIGallery.Views.Components.Forms;

public partial class CheckBoxPage : ContentPage
{
	public CheckBoxPage()
	{
		InitializeComponent();

        OnCheckObservable();
	}

    private void OnCheckObservable()
	{
        IObservable<bool> checkedObservable = Observable
            .FromEventPattern<CheckedChangedEventArgs>(
            handler => CheckedTest.CheckedChanged += handler,
            handler => CheckedTest.CheckedChanged -= handler
            ).Select(args => args.EventArgs.Value);

        _ = checkedObservable.Subscribe(
            val =>
            {
                DisplayAlert("The value is", $"{val}", "Ok");
            },
            ex =>
            {
                DisplayAlert("Error", "We got an exception", "Ok");
            }
        );
    }
}