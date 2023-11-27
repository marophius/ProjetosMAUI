namespace AppShoppingCenter
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            CustomHandler();
        }

        private void CustomHandler()
        {
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("EntryBorderLess", (handler, view) =>
            {
#if WINDOWS
                handler.PlatformView.BorderThickness = new Thickness(0).ToPlatform();
#endif

#if ANDROID
                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#endif
#if IOS || MACCATALYST
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
                handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
#endif

            });
        }
    }
}