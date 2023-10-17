using System.Reactive.Linq;

namespace MAUIGallery.Views.Components.Forms;

public partial class RadioButtonPage : ContentPage
{
	public RadioButtonPage()
	{
		InitializeComponent();

		var radioButtonObservable = Observable.Merge(
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
            );

        _ = radioButtonObservable
                        .Where(args => args.EventArgs.Value == true)
                        .Subscribe(
            args =>
            {
                var radioButton = (RadioButton)args.Sender;
                var value = radioButton.Content;

                radioButton.Dispatcher.Dispatch(() =>
                {
                    LblResultAsk01.IsVisible = true;
                    LblResultAsk01.Text = $"Você escolheu {value}";
                });
            }
            );
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
}