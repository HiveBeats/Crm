using Crm.Client.Application.Clients;
using Crm.Client.ViewModel.Common;
using ReactiveUI;
using System;
using System.Reactive;

namespace Crm.Client.ViewModel.Clients;
public class CreateClientOrderViewModel : ViewModelBase
{
	private string _name;
	private string _description;
	private ReactiveCommand<Unit, Unit> _createCommand;
	private readonly IObservable<bool> _nameValidation;
	private readonly Crm.Domain.Models.Client _client;
	private readonly IClientOrdersService _clientOrdersService;
	public CreateClientOrderViewModel(Crm.Domain.Models.Client client, IClientOrdersService clientOrdersService) : base(new ReactiveUI.ViewModelActivator())
	{
		_client = client;
		_clientOrdersService = clientOrdersService;
		_nameValidation = this.WhenAnyValue(x => x.Name, name => !string.IsNullOrWhiteSpace(name));
		CancelCommand = ReactiveCommand.Create(() => { });
	}

	public string Name
	{
		get => _name;
		set => SetProperty(ref _name, value);
	}

	public string Description
	{
		get => _description;
		set => SetProperty(ref _description, value);
	}

	public ReactiveCommand<Unit, Unit> CreateCommand => _createCommand ??= ReactiveCommand.CreateFromTask(async () =>
	{
		await _clientOrdersService.Create(_client, Name, Description);
	}, canExecute: _nameValidation);

	public ReactiveCommand<Unit, Unit> CancelCommand { get; }
}
