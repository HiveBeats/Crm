using System;
using Microsoft.Extensions.DependencyInjection;

namespace Crm.Client.ViewModel.Common;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _currentViewModel;

    public ViewModelBase CurrentViewModel
    {
        get => _currentViewModel;
        set => SetProperty(ref _currentViewModel, value);
    }

    public static IServiceProvider ServiceProvider { get; private set; }

    public void Initialize(IServiceProvider sp)
    {
        ServiceProvider = sp;
        CurrentViewModel = sp.GetRequiredService<NavigationViewModel>();
    }
}