using Maui.ProjectTo.Updater.ViewModels;

namespace Maui.ProjectTo.Updater
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel mainPageViewModel)
        {
            InitializeComponent();
            this.BindingContext = mainPageViewModel;
        }
    }
}