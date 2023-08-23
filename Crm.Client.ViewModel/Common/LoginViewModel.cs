﻿using Crm.Client.Application.Authentication;
using ReactiveUI;
using Splat;
using System.Windows.Input;

namespace Crm.Client.ViewModel.Common;

public class LoginViewModel : ViewModelBase, IPageViewModel
{
	private string _userName;
	private string _password;

	private readonly IAuthConfiguration _auth;
	private readonly IAuthService _authService;
	
	public LoginViewModel() : base(new ViewModelActivator())
	{
		_auth = Locator.Current.GetService<IAuthConfiguration>();
		_authService = Locator.Current.GetService<IAuthService>();

		LoginCommand = ReactiveCommand.CreateFromTask(async () =>
		{
			await Login();
		});
	}

	public string UserName { get => _userName; set => this.RaiseAndSetIfChanged(ref _userName, value); }
	public string Password { get => _password; set => this.RaiseAndSetIfChanged(ref _password, value); }
	public ICommand LoginCommand { get; }

	private async System.Threading.Tasks.Task Login()
	{
		var user = await _authService.Login(UserName, Password);
		//todo: save this state somehow or send message
	}
}
