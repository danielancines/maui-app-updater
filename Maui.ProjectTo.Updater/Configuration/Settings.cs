namespace Maui.ProjectTo.Updater.Configuration;

public class Settings
{
    public string Uri { get; set; }
    public string ManifestFile { get; set; }
    public UpdateSourceType Type { get; set; }
}

public enum UpdateSourceType
{
    Network,
    Uri
}

public class Manifest
{
    public string LastVersion { get; set; }
}