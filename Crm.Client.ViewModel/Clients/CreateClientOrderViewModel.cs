using System;
using CommunityToolkit.Mvvm.Input;
using Crm.Client.Application.Clients;
using Crm.Client.ViewModel.Common;
using HanumanInstitute.MvvmDialogs;

namespace Crm.Client.ViewModel.Clients;

public partial class CreateClientOrderViewModel : ViewModelBase, IModalDialogViewModel, ICloseable
{
    private readonly Domain.Models.Client _client;
    private readonly IClientOrdersService _clientOrdersService;
    private string _description;
    private string _name;

    public CreateClientOrderViewModel(
        Domain.Models.Client client,
        IClientOrdersService clientOrdersService)
    {
        _client = client;
        _clientOrdersService = clientOrdersService;
        CreateCommand = new RelayCommand(Create, CanCreate);
    }

    public Guid OrderId { get; set; }

    public string Name
    {
        get => _name;
        set
        {
            SetProperty(ref _name, value);
            CreateCommand.NotifyCanExecuteChanged();
        }
    }

    public string Description
    {
        get => _description;
        set => SetProperty(ref _description, value);
    }

    public RelayCommand CreateCommand { get; }

    public event EventHandler RequestClose;

    public bool? DialogResult { get; set; }

    private async void Create()
    {
        DialogResult = true;
        OrderId = await _clientOrdersService.Create(_client, Name, Description);
        RequestClose?.Invoke(this, EventArgs.Empty);
    }

    private bool CanCreate()
    {
        return Name is not null ? true : false;
    }

    [RelayCommand]
    private void Cancel()
    {
        DialogResult = false;
        RequestClose?.Invoke(this, EventArgs.Empty);
    }
}