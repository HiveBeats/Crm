
using AutoMapper;
using Crm.Client.Application.Clients;
using Crm.Client.ViewModel.Clients;
using Crm.Client.ViewModel.Common;
using Crm.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using Splat;

namespace Crm.Client.Avalonia.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private Crm.Client.ViewModel.Common.ViewModelBase _currentViewModel;
    public MainWindowViewModel()
    {
        Locator.CurrentMutable.RegisterConstant(this);
        
        Bootstrapper.InjectServices();
        Bootstrapper.InjectViewModels();
        CurrentViewModel = Locator.Current.GetService<ClientsViewModel>();
    }

    
    public string Greeting => "Welcome to Avalonia!";

    public Crm.Client.ViewModel.Common.ViewModelBase CurrentViewModel 
    { 
        get => _currentViewModel; 
        set => this.RaiseAndSetIfChanged(ref _currentViewModel, value); 
    }
}
