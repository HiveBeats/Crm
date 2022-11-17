using Crm.Client.Application.Authentication;
using ReactiveUI;
using System.Windows.Input;

namespace Crm.Client.ViewModel.Common;

public class LoginViewModel : ViewModelBase
{
	private string _userName;
	private string _password;

	private readonly IAuthConfiguration _auth;
	private readonly IAuthService _authService;
	public LoginViewModel(IAuthConfiguration authConfiguration, IAuthService authService) : base(new ViewModelActivator())
	{
		_auth = authConfiguration;
		_authService = authService;

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
