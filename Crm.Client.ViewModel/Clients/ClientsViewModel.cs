using Crm.Client.Application.Clients;
using Crm.Client.ViewModel.Common;
using ReactiveUI;
using Splat;
using System;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using HanumanInstitute.MvvmDialogs;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace Crm.Client.ViewModel.Clients;

[UsedImplicitly]
public partial class ClientsViewModel : ItemsViewModel<Domain.Models.Client>, IPageViewModel
{
    private readonly IClientOrdersService _clientOrdersService;
    private readonly IDialogService _dialogService;
    private readonly MainWindowViewModel _mainWindowViewModel;
    
    public ClientsViewModel(
        IClientService clientService, 
        IClientOrdersService clientOrdersService,
        IDialogService dialogService,
        MainWindowViewModel mainWindowViewModel) : base(new ViewModelActivator())
    {
        ItemsService = clientService;
        _clientOrdersService = clientOrdersService;
        _dialogService = dialogService;
        _mainWindowViewModel = mainWindowViewModel;
        RxApp.MainThreadScheduler.ScheduleAsync(OnLoaded);
    }

    [RelayCommand]
    private async Task CreateOrderCommand()
    {
        var dialogViewModel = new CreateClientOrderViewModel(CurrentItem, _clientOrdersService);
        var result = await _dialogService.ShowDialogAsync(_mainWindowViewModel, dialogViewModel);
    }
}
