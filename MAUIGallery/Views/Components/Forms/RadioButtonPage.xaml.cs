using System.Reactive.Linq;

namespace MAUIGallery.Views.Components.Forms;

public partial class RadioButtonPage : ContentPage
{
    private IDisposable _subscription;
	public RadioButtonPage()
	{
		InitializeComponent();

		
	}

    private void CreateAllCheckedChangesObservable()
    {
        _subscription =  Observable.Merge(
            Observable.FromEventPattern<CheckedChangedEventArgs>(
                handler => CheckedTest.CheckedChanged += handler,
                handler => CheckedTest.CheckedChanged -= handler
                ),
            Observable.FromEventPattern<CheckedChangedEventArgs>(
                handler => CheckedTest2.CheckedChanged += handler,
                handler => CheckedTest2.CheckedChanged -= handler
                ),
            Observable.FromEventPattern<CheckedChangedEventArgs>(
                handler => CheckedTest3.CheckedChanged += handler,
                handler => CheckedTest3.CheckedChanged -= handler
                )
            ).Where(args => args.EventArgs.Value == true)
            .Do(args =>
            {
                var radioButton = (RadioButton)args.Sender;
                var value = radioButton.Content;

                radioButton.Dispatcher.Dispatch(() =>
                {
                    LblResultAsk01.IsVisible = true;
                    LblResultAsk01.Text = $"Você escolheu {value}";
                });
            }).Subscribe();
    }

    private void CreateCheckedChangeObservable()
    {
        _subscription = Observable.FromEventPattern<CheckedChangedEventArgs>(
            handler => CheckedTest.CheckedChanged += handler,
            handler => CheckedTest.CheckedChanged -= handler)
            .Where(args => args.EventArgs.Value == true)
            .Do(e =>
            {
                var radioButton = (RadioButton)e.Sender;
                var value = radioButton.Content;

                radioButton.Dispatcher.Dispatch(() =>
                {
                    LblResultAsk01.IsVisible = true;
                    LblResultAsk01.Text = $"Você escolheu {value}";
                });
            }).Subscribe();
    }

    private void CheckedTest_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
		if(e.Value == true)
		{
			var value = ((RadioButton)sender).Content;
            LblResultAsk01.IsVisible = true;
            LblResultAsk01.Text = $"Você escolheu {value}";
        }
    }

    protected override void OnDisappearing()
    {
        _subscription.Dispose();
        base.OnDisappearing();
    }
}