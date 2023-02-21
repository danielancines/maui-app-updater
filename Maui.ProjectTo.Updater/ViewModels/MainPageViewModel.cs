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

    [RelayCommand]
    void Update()
    {
        Shell.Current.DisplayAlert(this._updaterService.FilesCount().Result.ToString(), TraderApplication.Instance.Configuration.Uri, "Ok");

        

        //foreach (var item in Directory.EnumerateFiles(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "").Replace("\\Updater", "")).Where(i => i.Contains(".exe")))
        //{
        //    Shell.Current.DisplayAlert("Message", item, "Ok");
        //}
    }
}
