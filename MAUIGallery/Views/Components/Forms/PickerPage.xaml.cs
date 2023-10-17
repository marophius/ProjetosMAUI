using System.Reactive.Linq;

namespace MAUIGallery.Views.Components.Forms;

public partial class PickerPage : ContentPage
{
	private IDisposable _pickerSubscription;
	public PickerPage()
	{
		InitializeComponent();
		CreatePickerObservable();
	}

	private void CreatePickerObservable()
	{
		_pickerSubscription = Observable.FromEventPattern<EventHandler, EventArgs>(
			handler => PickerTest.SelectedIndexChanged += handler,
			handler => PickerTest.SelectedIndexChanged -= handler
			).Subscribe(val =>
			{
				PickerTest.Dispatcher.Dispatch(() =>
				{
					LblValue.Text = $"O index atual é: {(string)PickerTest.SelectedItem}";
				});
			});
	}

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
		_pickerSubscription?.Dispose();
    }
}