using Maui.ProjectTo.Updater.ViewModels;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Reflection;

namespace Maui.ProjectTo.Updater.Configuration;

public static class UpdaterConfiguration
{
    public static MauiAppBuilder ConfigureUpdater(this MauiAppBuilder builder)
    {
        RegisterPages(builder);
        RegisterViewModels(builder);
        LoadConfigurations(builder);
        return builder;
    }

    public static void InitializeUpdaterConfiguration(IServiceProvider serviceProvider)
    {
        var configuration = serviceProvider.GetService<IConfiguration>();
        var settings = configuration.GetRequiredSection("Settings").Get<Settings>();

        TraderApplication.Instance.ServerUri = settings.Uri;
    }

    static void RegisterViewModels(MauiAppBuilder builder)
    {
        builder.Services.AddTransient<MainPageViewModel>();
    }

    static void RegisterPages(MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<MainPage>();
    }

    static void LoadConfigurations(MauiAppBuilder builder)
    {
        TraderApplication.Instance.CurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "");
        if (string.IsNullOrEmpty(TraderApplication.Instance.CurrentDirectory))
            throw new FileNotFoundException("Configuration File Not Found");

        var a = Assembly.GetExecutingAssembly();
        using var streamReader = new StreamReader(Path.Combine(TraderApplication.Instance.CurrentDirectory, "Configuration/Updater.json"));

        var config = new ConfigurationBuilder()
                    .AddJsonStream(streamReader.BaseStream)
                    .Build();


        builder.Configuration.AddConfiguration(config);
    }
}
