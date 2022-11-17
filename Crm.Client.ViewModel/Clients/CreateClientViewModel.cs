using Crm.Client.Application.Clients;
using Crm.Client.ViewModel.Common;
using ReactiveUI;
using System;

namespace Crm.Client.ViewModel.Clients;
public class CreateClientViewModel : ViewModelBase
{
    private string _name;
    private string _contact;
    private IReactiveCommand _createCommand;
    private IObservable<bool> _nameValidation;
    private readonly IClientService _clientService;
    public CreateClientViewModel(IClientService clientService) : base(new ViewModelActivator())
    {
        _clientService = clientService;
        _nameValidation = this.WhenAnyValue(x => x.Name, name => !string.IsNullOrWhiteSpace(name));
    }

    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    public string Contact
    {
        get => _contact;
        set => this.RaiseAndSetIfChanged(ref _contact, value);
    }

    public IReactiveCommand CreateCommand => _createCommand ?? (_createCommand = ReactiveCommand.CreateFromTask(async () =>
    {
        await _clientService.Create(_name, _contact);
    }, canExecute: _nameValidation));
}
