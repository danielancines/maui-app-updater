using Maui.ProjectTo.Updater.Configuration;
using Microsoft.Extensions.Logging;

namespace Maui.ProjectTo.Updater
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureUpdater()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });



#if DEBUG
		builder.Logging.AddDebug();
#endif

            var app = builder.Build();
            UpdaterConfiguration.InitializeUpdaterConfiguration(app.Services);
            return app;
        }
    }
}