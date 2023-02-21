namespace Maui.ProjectTo.Updater.Services.Contracts;

public interface IUpdaterService
{
    Task<int> FilesCount();
    Task<string> LastVersion();
}
