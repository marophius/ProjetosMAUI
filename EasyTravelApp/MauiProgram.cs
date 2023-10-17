using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace EasyTravelApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
#if ANDROID
EntryHandler.Mapper.AppendToMapping("NoUnderLine", (h, v) =>
            {
                h.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToPlatform());

            });

            DatePickerHandler.Mapper.AppendToMapping("NoUnderLine", (h, v) =>
            {
                h.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToPlatform());
                h.PlatformView.TextAlignment= Android.Views.TextAlignment.ViewStart;
            });

            PickerHandler.Mapper.AppendToMapping("NoUnderline", (h, v) =>
		{
			h.PlatformView.BackgroundTintList = 
				Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToPlatform());
		});
#endif
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Barlow-Bold.ttf", "BarlowBold");
                    fonts.AddFont("Barlow-Medium.ttf", "BarlowMedium");
                    fonts.AddFont("Barlow-Refular.ttf", "BarlowRegular");
                    fonts.AddFont("Barlow-Semibold.ttf", "BarlowSemibold");
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                }).ConfigureMauiHandlers(handlers =>
                {
#if ANDROID
handlers.AddHandler(typeof(Shell), typeof(Platforms.Android.CustomShellRender));
#endif
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}