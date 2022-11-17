﻿using Crm.Client.Application.Clients;
using Crm.Client.ViewModel.Common;
using ReactiveUI;
using System;

namespace Crm.Client.ViewModel.Clients;
public class CreateClientOrderViewModel : ViewModelBase
{
	private string _name;
	private string _description;
	private IReactiveCommand _createCommand;
	private IObservable<bool> _nameValidation;
	private Crm.Domain.Models.Client _client;
	private readonly IClientOrdersService _clientOrdersService;
	public CreateClientOrderViewModel(Crm.Domain.Models.Client client, IClientOrdersService clientOrdersService) : base(new ReactiveUI.ViewModelActivator())
	{
		_client = client;
		_clientOrdersService = clientOrdersService;

		_nameValidation = this.WhenAnyValue(x => x.Name, name => !string.IsNullOrWhiteSpace(name));
	}

	public string Name
	{
		get => _name;
		set => this.RaiseAndSetIfChanged(ref _name, value);
	}

	public string Description
	{
		get => _description;
		set => this.RaiseAndSetIfChanged(ref _description, value);
	}

	public IReactiveCommand CreateCommand => _createCommand ?? (_createCommand = ReactiveCommand.CreateFromTask(async () =>
	{
		await _clientOrdersService.Create(_client, Name, Description);
	}, canExecute: _nameValidation));
}