using Caliburn.Micro;

namespace DemoBug.ViewModels;

public class FirstViewModel : Screen
{
    private string title = "First View";

    public string Title { get => title; set => Set(ref title, value); }
    public FirstViewModel()
    {
        DisplayName = Title;
    }
}
