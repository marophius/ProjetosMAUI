using AppTask.Data;
using AppTask.Data.Repositories;
using AppTask.Services;
using Microsoft.Extensions.Logging;

namespace AppTask
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<ApplicationDbContext>();
            builder.Services.AddSingleton<ITaskModelRepository, TaskModelRepository>();
            builder.Services.AddSingleton<TaskStore>();
            builder.Services.AddSingleton<TaskService>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}