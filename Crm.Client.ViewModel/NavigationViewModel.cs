using System.Reactive;
using Crm.Client.ViewModel.Clients;
using Crm.Client.ViewModel.Common;
using Crm.Client.ViewModel.Departments;
using Crm.Client.ViewModel.Resources;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;

namespace Crm.Client.ViewModel;

public class NavigationViewModel : ViewModelBase, IPageViewModel
{
    private readonly ClientsPageViewModel _clientsViewModel;
    private readonly DepartmentsViewModel _departmentsViewModel;
    private readonly ResourcesViewModel _resourcesViewModel;
    private ViewModelBase _currentContext;
    private ReactiveCommand<string, Unit> _navigateCommand;

    public NavigationViewModel()
    {
        _resourcesViewModel = MainWindowViewModel.ServiceProvider.GetRequiredService<ResourcesViewModel>();
        _departmentsViewModel = MainWindowViewModel.ServiceProvider.GetRequiredService<DepartmentsViewModel>();
        _clientsViewModel = MainWindowViewModel.ServiceProvider.GetRequiredService<ClientsPageViewModel>();
        CurrentContext = _clientsViewModel;
    }

    [UsedImplicitly]
    public ViewModelBase CurrentContext
    {
        get => _currentContext;
        set => SetProperty(ref _currentContext, value);
    }

    [UsedImplicitly]
    public ReactiveCommand<string, Unit> NavigateCommand => _navigateCommand ??= ReactiveCommand.Create<string>(name =>
    {
        CurrentContext = name switch
        {
            "Client" => _clientsViewModel,
            "Resource" => _resourcesViewModel,
            "Employee" => _departmentsViewModel,
            _ => CurrentContext
        };
    });
}