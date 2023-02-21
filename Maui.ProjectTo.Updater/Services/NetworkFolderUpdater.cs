using Maui.ProjectTo.Updater.Services.Contracts;

namespace Maui.ProjectTo.Updater.Services;

public class NetworkFolderUpdater : IUpdaterService
{
    public Task<int> FilesCount()
    {
        var count = Directory.EnumerateFiles("C:\\Users\\danie\\Documents\\code\\Maui.ProjectToUpdate\\Maui.ProjectToUpdate\\bin\\x64\\Release\\net7.0-windows10.0.19041.0\\win10-x64", "*.*", SearchOption.AllDirectories).Count();
        return Task.FromResult(count);
    }

    public Task<string> LastVersion()
    {
        throw new NotImplementedException();
    }
}
