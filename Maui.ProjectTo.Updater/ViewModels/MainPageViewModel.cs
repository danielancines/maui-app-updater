using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui.ProjectTo.Updater.Services.Contracts;

namespace Maui.ProjectTo.Updater.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    readonly IUpdaterService _updaterService;

    public MainPageViewModel(IUpdaterService updaterService)
    {
        this._updaterService = updaterService;
    }

    [ObservableProperty]
    double downloadProgress;

    [ObservableProperty]
    string downloadingFileName;

    [RelayCommand]
    async void Update()
    {
        //Shell.Current.DisplayAlert((await this._updaterService.FilesCount()).ToString(), TraderApplication.Instance.Configuration.Uri, "Ok");
        var count = 0;
        var files = await this._updaterService.BeginDownload();
        foreach (var file in files)
        {
            this.DownloadingFileName = Path.GetFileName(file);
            count++;
            this.DownloadProgress = (count * 100) / files.Count / 100f;
            var fileData = await this._updaterService.DownloadAsync(file);
            var filePath = $"c:\\Temp\\Updater\\{file}";

            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            using var fileStream = new FileInfo(filePath).OpenWrite();
            fileStream.Write(fileData);
        }

        Shell.Current.DisplayAlert((await this._updaterService.FilesCount()).ToString(), TraderApplication.Instance.Configuration.Uri, "Ok");

        //foreach (var item in Directory.EnumerateFiles(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "").Replace("\\Updater", "")).Where(i => i.Contains(".exe")))
        //{
        //    Shell.Current.DisplayAlert("Message", item, "Ok");
        //}
    }
}
