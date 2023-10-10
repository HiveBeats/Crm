using System.Reactive.Concurrency;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Crm.Client.Application.Clients;
using Crm.Client.ViewModel.Common;
using HanumanInstitute.MvvmDialogs;
using JetBrains.Annotations;
using ReactiveUI;

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
        MainWindowViewModel mainWindowViewModel)
    {
        ItemsService = clientService;
        _clientOrdersService = clientOrdersService;
        _dialogService = dialogService;
        _mainWindowViewModel = mainWindowViewModel;
    }

    [RelayCommand]
    private async Task CreateOrderCommand()
    {
        var dialogViewModel = new CreateClientOrderViewModel(CurrentItem, _clientOrdersService);
        var result = await _dialogService.ShowDialogAsync(_mainWindowViewModel, dialogViewModel);
    }
}