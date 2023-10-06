using System;
using CommunityToolkit.Mvvm.Input;
using Crm.Client.Application.Clients;
using Crm.Client.ViewModel.Common;
using Crm.Domain.Models;
using ReactiveUI;
using Task = System.Threading.Tasks.Task;

namespace Crm.Client.ViewModel.Clients;

public class CreateClientViewModel : ViewModelBase
{
    private readonly IClientService _clientService;
    private string _contact;
    private string _name;

    public CreateClientViewModel(IClientService clientService)
    {
        _clientService = clientService;
        CreateCommand = new AsyncRelayCommand(Create, CanCreate);
    }

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public string Contact
    {
        get => _contact;
        set => SetProperty(ref _contact, value);
    }

    public AsyncRelayCommand CreateCommand { get; }
    private async Task Create()
    {
        await _clientService.Create(_name, _contact);
    }

    private bool CanCreate()
    {
        return Name is not null ? true : false;
    }
}