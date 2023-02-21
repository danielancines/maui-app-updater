using Maui.ProjectTo.Updater.Services;
using Maui.ProjectTo.Updater.Services.Contracts;
using Maui.ProjectTo.Updater.ViewModels;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Maui.ProjectTo.Updater.Configuration;

public static class UpdaterConfiguration
{
    public static MauiAppBuilder ConfigureUpdater(this MauiAppBuilder builder)
    {
        RegisterPages(builder);
        RegisterViewModels(builder);
        LoadConfigurations(builder);
        RegisterServices(builder);
        return builder;
    }

    static void RegisterServices(MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<IUpdaterService, NetworkFolderUpdater>();
    }

    public static void InitializeUpdaterConfiguration(IServiceProvider serviceProvider)
    {
        try
        {
            var configuration = serviceProvider.GetService<IConfiguration>();
            var settings = configuration.GetRequiredSection("Settings").Get<Settings>();

            TraderApplication.Instance.InitializeConfiguration(settings);
        }
        catch (Exception)
        {
            //TODO Handle exception
        }
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
        TraderApplication.Instance.InitializeCurrentDirectory(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", ""));
        if (string.IsNullOrEmpty(TraderApplication.Instance.CurrentDirectory))
            throw new FileNotFoundException("Configuration File Not Found");

        var a = Assembly.GetExecutingAssembly();
        var configPath = Path.Combine(TraderApplication.Instance.CurrentDirectory, "Configuration/Updater.json");

        if (!File.Exists(configPath))
            return;

        using var streamReader = new StreamReader(configPath);

        var config = new ConfigurationBuilder()
                    .AddJsonStream(streamReader.BaseStream)
                    .Build();

        builder.Configuration.AddConfiguration(config);
    }
}
