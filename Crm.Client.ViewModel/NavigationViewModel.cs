using CommunityToolkit.Mvvm.Input;
using Crm.Client.ViewModel.Clients;
using Crm.Client.ViewModel.Common;
using Crm.Client.ViewModel.Departments;
using Crm.Client.ViewModel.Resources;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace Crm.Client.ViewModel;

public class NavigationViewModel : ViewModelBase, IPageViewModel
{
    private readonly ClientsPageViewModel _clientsViewModel;
    private readonly DepartmentsViewModel _departmentsViewModel;
    private readonly ResourcesViewModel _resourcesViewModel;
    private ViewModelBase _currentContext;
    private InitializableViewModelFactory _factory;
    public NavigationViewModel(InitializableViewModelFactory factory)
    {
        _factory = factory;
        _resourcesViewModel = _factory.Create<ResourcesViewModel>();
        _departmentsViewModel = _factory.Create<DepartmentsViewModel>();
        _clientsViewModel = _factory.Create<ClientsPageViewModel>();
        CurrentContext = _clientsViewModel;
        NavigateCommand = new RelayCommand<string>(Navigate);
    }

    [UsedImplicitly]
    public ViewModelBase CurrentContext
    {
        get => _currentContext;
        set => SetProperty(ref _currentContext, value);
    }

    public RelayCommand<string> NavigateCommand { get; }
    private void Navigate(string name)
    {
        CurrentContext = name switch
        {
            "Client" => _clientsViewModel,
            "Resource" => _resourcesViewModel,
            "Employee" => _departmentsViewModel,
            _ => CurrentContext
        };
    }
}