using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Maui.ProjectTo.Updater.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    [RelayCommand]
    void Update()
    {
        Shell.Current.DisplayAlert("Message", TraderApplication.Instance.ServerUri, "Ok");
        //foreach (var item in Directory.EnumerateFiles(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "").Replace("\\Updater", "")).Where(i => i.Contains(".exe")))
        //{
        //    Shell.Current.DisplayAlert("Message", item, "Ok");
        //}
    }
}
