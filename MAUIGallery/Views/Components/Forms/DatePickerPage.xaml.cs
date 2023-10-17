using Microsoft.Maui.Controls;
using System.Reactive.Linq;

namespace MAUIGallery.Views.Components.Forms;

public partial class DatePickerPage : ContentPage
{
	private IDisposable _datePickerSubscription;
	public DatePickerPage()
	{
		InitializeComponent();
		CreateDateSelectHandler();
	}

	private void CreateDateSelectHandler()
	{
		_datePickerSubscription = Observable.FromEventPattern<DateChangedEventArgs>(
			handler => DatePickerTest.DateSelected += handler,
			handler => DatePickerTest.DateSelected -= handler
			).Select(args => args.EventArgs.NewDate)
			.Subscribe(val => AlterarLbl(val.ToString()));
	}

	private void AlterarLbl(string value)
	{
		LblValue.Text = $"{value}";
	}

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

		_datePickerSubscription?.Dispose();
    }
}