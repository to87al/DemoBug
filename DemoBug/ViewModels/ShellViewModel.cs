using Caliburn.Micro;

namespace DemoBug.ViewModels;

public class ShellViewModel : Screen
{
    private readonly IWindowManager _windowManager;
    public ShellViewModel(IWindowManager windowManager)
    {
        _windowManager = windowManager;
        DisplayName = Title;
    }
    private string title = "Shell View";

    public string Title { get => title; set => Set(ref title, value); }

    public void ShowTabs()
    {
        _windowManager.ShowWindowAsync(IoC.Get<TabsViewModel>());
    }
}
