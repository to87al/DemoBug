using Caliburn.Micro;

namespace DemoBug.ViewModels;

public class ThirdViewModel : Screen
{
    public ThirdViewModel()
    {
        DisplayName = Title;
    }
    private string title = "Third View";

    public string Title { get => title; set => Set(ref title, value); }
}