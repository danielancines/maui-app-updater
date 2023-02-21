using Maui.ProjectTo.Updater.Configuration;

namespace Maui.ProjectTo.Updater;

public class TraderApplication
{
    public Settings Configuration { get; private set; }
    public string CurrentDirectory { get; private set; }
    public static TraderApplication Instance { get; } = new TraderApplication();
    private TraderApplication() { }

    internal void InitializeConfiguration(Settings configuration)
    {
        if (this.Configuration != null)
            return;

        this.Configuration = configuration;
    }

    internal void InitializeCurrentDirectory(string currentDirectory)
    {
        if (!string.IsNullOrEmpty(this.CurrentDirectory))
            return;

        this.CurrentDirectory = currentDirectory;
    }
}
