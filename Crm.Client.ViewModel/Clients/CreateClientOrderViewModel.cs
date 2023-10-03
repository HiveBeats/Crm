using Crm.Client.Application.Clients;
using Crm.Client.ViewModel.Common;
using ReactiveUI;
using System;
using System.Reactive;
using CommunityToolkit.Mvvm.Input;
using Crm.Domain.Models;
using HanumanInstitute.MvvmDialogs;

namespace Crm.Client.ViewModel.Clients;
public partial class CreateClientOrderViewModel : ViewModelBase, IModalDialogViewModel, ICloseable
{
	private string _name;
	private string _description;
	private readonly IObservable<bool> _nameValidation;
	private readonly Domain.Models.Client _client;
	private readonly IClientOrdersService _clientOrdersService;
	
	public CreateClientOrderViewModel(
		Crm.Domain.Models.Client client, 
		IClientOrdersService clientOrdersService) : base(new ReactiveUI.ViewModelActivator())
	{
		_client = client;
		_clientOrdersService = clientOrdersService;
		OkCommand = new RelayCommand(Ok, CanOk);
	}

	public bool? DialogResult { get; set; }
	public Guid OrderId { get; set; }

	public string Name
	{
		get => _name;
		set
		{
			SetProperty(ref _name, value);
			this.OkCommand.NotifyCanExecuteChanged();
		}
	}

	public string Description
	{
		get => _description;
		set => SetProperty(ref _description, value);
	}

	public RelayCommand OkCommand { get; }
	private async void Ok()
	{
		DialogResult = true;
		OrderId = await _clientOrdersService.Create(_client, Name, Description);
		RequestClose?.Invoke(this, EventArgs.Empty);
	}
	private bool CanOk() => Name is not null ? true : false;

	public event EventHandler RequestClose;
	[RelayCommand]
	private void Cancel()
	{
		DialogResult = false;
		RequestClose?.Invoke(this, EventArgs.Empty);
	}
}
