using AppTask.Data.Repositories;
using AppTask.Services;
using AppTask.Views;
using Microsoft.Maui.Platform;

namespace AppTask
{
    public partial class App : Application
    {
        private readonly TaskService taskService;
        public App(TaskService service)
        {
            CustomHandler();
            InitializeComponent();
            taskService = service;
            MainPage = new NavigationPage(new StartPage(service));
        }

        private void CustomHandler()
        {
            EntryNoBorder();
            DatePickerNoBorder();
            EditorNoBorder();
        }

        private static void EntryNoBorder()
        {
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoBorder", (handler, view) =>
            {
                // ANDROID 
#if ANDROID
                handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToPlatform());

#endif

                // IOS
#if IOS || MACCATALYST
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif

                // WINDOWS 

#if WINDOWS

                handler.PlatformView.BorderThickness = new Thickness(0).ToPlatform();
#endif
            });
        }

        private static void DatePickerNoBorder()
        {
            Microsoft.Maui.Handlers.DatePickerHandler.Mapper.AppendToMapping("NoBorder", (handler, view) =>
            {
                // ANDROID 
#if ANDROID
                handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToPlatform());

#endif

                // IOS
#if IOS || MACCATALYST
                //handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif

                // WINDOWS 

#if WINDOWS

                handler.PlatformView.BorderThickness = new Thickness(0).ToPlatform();
#endif
            });
        }

        private static void EditorNoBorder()
        {
            Microsoft.Maui.Handlers.EditorHandler.Mapper.AppendToMapping("NoBorder", (handler, view) =>
            {
                // ANDROID 
#if ANDROID
                handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToPlatform());

#endif

                // IOS
#if IOS || MACCATALYST
                //handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif

                // WINDOWS 

#if WINDOWS

                handler.PlatformView.BorderThickness = new Thickness(0).ToPlatform();
#endif
            });
        }

        protected override void OnSleep()
        {
            taskService.ClearFullState();
            base.OnSleep();
        }
    }
}