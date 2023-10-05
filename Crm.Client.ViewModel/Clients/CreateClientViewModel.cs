using System;
using Crm.Client.Application.Clients;
using Crm.Client.ViewModel.Common;
using ReactiveUI;

namespace Crm.Client.ViewModel.Clients;

public class CreateClientViewModel : ViewModelBase
{
    private readonly IClientService _clientService;
    private readonly IObservable<bool> _nameValidation;
    private string _contact;
    private IReactiveCommand _createCommand;
    private string _name;

    public CreateClientViewModel(IClientService clientService)
    {
        _clientService = clientService;
        _nameValidation = this.WhenAnyValue(x => x.Name, name => !string.IsNullOrWhiteSpace(name));
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

    public IReactiveCommand CreateCommand => _createCommand ??=
        ReactiveCommand.CreateFromTask(async () => { await _clientService.Create(_name, _contact); }, _nameValidation);
}