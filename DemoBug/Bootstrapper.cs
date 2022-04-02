using Caliburn.Micro;
using DemoBug.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Threading;

namespace DemoBug;

public class Bootstrapper : BootstrapperBase
{
    private readonly SimpleContainer _container = new();
    public Bootstrapper()
    {
        Initialize();
    }
    protected override void Configure()
    {
        _container.Instance(_container);
        _container
            .Singleton<IWindowManager, WindowManager>()
            .Singleton<IEventAggregator, EventAggregator>();

        GetType().Assembly.GetTypes()
            .Where(type => type.IsClass && type.Name.EndsWith("ViewModel", StringComparison.Ordinal))
            .ToList()
            .ForEach(viewModelType => _container.RegisterPerRequest(viewModelType, viewModelType.ToString(), viewModelType));
    }
    protected override void OnStartup(object sender, StartupEventArgs e)
    {
        DisplayRootViewForAsync<ShellViewModel>();
    }
    protected override object GetInstance(Type service, string key)
    {
        return _container.GetInstance(service, key);
    }
    protected override IEnumerable<object> GetAllInstances(Type service)
    {
        return _container.GetAllInstances(service);
    }
    protected override void BuildUp(object instance)
    {
        _container.BuildUp(instance);
    }
    protected override void OnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        e.Handled = true;
        MessageBox.Show($"{e.Exception.Message}\n\r{e.Exception.InnerException}", "An error as occurred! (Bootstrapper)", MessageBoxButton.OK);
    }
}
