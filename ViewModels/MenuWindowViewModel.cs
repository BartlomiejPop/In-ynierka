using CommunityToolkit.Mvvm.ComponentModel;

namespace GetStartedApp.ViewModels;

public partial class MenuWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private object? currentView;

    public MenuWindowViewModel()
    {
        CurrentView = null;
    }
}
