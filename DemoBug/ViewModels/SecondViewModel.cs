using Caliburn.Micro;

namespace DemoBug.ViewModels;

public class SecondViewModel : Screen
{
    public SecondViewModel()
    {
        DisplayName = Title;
    }
    private string title = "Second View";

    public string Title { get => title; set => Set(ref title, value); }
}
