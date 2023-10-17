using System.Reactive.Linq;

namespace MAUIGallery.Views.Components.Forms;

public partial class SliderPage : ContentPage
{
    private IDisposable _dragStartedSubscription;
    private IDisposable _dragEndSubscription;
    private IDisposable _valueChangedSubscription;
    public SliderPage()
	{
		InitializeComponent();
        SubscribeToSliderEvents();
	}

    private void SubscribeToSliderEvents()
    {
        _dragStartedSubscription = Observable.FromEventPattern<EventHandler, EventArgs>(
            handler => SliderTest.DragStarted += handler,
            handler => SliderTest.DragStarted -= handler
            ).Subscribe(args =>
            {
                UpdateStatusLabel("Iniciou o arrasto");
            });

        _dragEndSubscription = Observable.FromEventPattern<EventHandler, EventArgs>(
            handler => SliderTest.DragCompleted += handler,
            handler => SliderTest.DragCompleted -= handler
            ).Subscribe(args =>
            {
                UpdateStatusLabel("Terminou o arrasto");
            });

        _valueChangedSubscription = Observable.FromEventPattern<ValueChangedEventArgs>(
            handler => SliderTest.ValueChanged += handler,
            handler => SliderTest.ValueChanged -= handler
            ).Select(args => args.EventArgs.NewValue)
            .Subscribe(val => UpdateValueChangedLabel($"O valor é: {val.ToString("C")}"));
    }

    private void UpdateStatusLabel(string value)
    {
        LblStatus.Text = value;
    }

    private void UpdateValueChangedLabel(string value)
    {
        LblValueChanged.Text = value;
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        _dragStartedSubscription?.Dispose();
        _dragEndSubscription?.Dispose();
        _valueChangedSubscription?.Dispose();
    }
}