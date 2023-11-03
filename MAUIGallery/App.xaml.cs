using System.Reactive.Linq;

namespace MAUIGallery
{
    public partial class App : Application
    {
        private IDisposable _subscription;
        public App()
        {
            InitializeComponent();

            MainPage = new AppFlyout();

            CreateThemeObservable();
        }

        private void CreateThemeObservable()
        {
            _subscription = Observable.FromEventPattern<AppThemeChangedEventArgs>(
                handler => App.Current.RequestedThemeChanged += handler,
                handler => App.Current.RequestedThemeChanged -= handler)
                .Do(e =>
                {
                if (e.EventArgs.RequestedTheme == AppTheme.Light)
                    {
                        App.Current.MainPage.DisplayAlert("Troca de tema", "Trocou para o tema claro", "OK");
                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("Troca de tema", "Trocou para o tema escuro", "OK");
                    }
                })
                .Subscribe();
        }

        protected override void OnSleep()
        {
            _subscription.Dispose();
            base.OnSleep();
        }
    }
}