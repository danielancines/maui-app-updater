namespace Maui.ProjectTo.Updater;

public class TraderApplication
{
    public string ServerUri { get; internal set; }
    public string CurrentDirectory { get; set; }
    public static TraderApplication Instance { get; } = new TraderApplication();
    private TraderApplication() { }
}
