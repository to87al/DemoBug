using Caliburn.Micro;

namespace DemoBug.ViewModels;

public class TabsViewModel : Conductor<IScreen>.Collection.OneActive
{
    public TabsViewModel()
    {
        DisplayName = "Tabs window";
        Items.Add(IoC.Get<FirstViewModel>());
        Items.Add(IoC.Get<SecondViewModel>());
        Items.Add(IoC.Get<ThirdViewModel>());
    }
}
