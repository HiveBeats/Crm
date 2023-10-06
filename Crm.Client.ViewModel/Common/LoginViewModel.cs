using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Crm.Client.Application.Authentication;
using ReactiveUI;

namespace Crm.Client.ViewModel.Common;

public class LoginViewModel : ViewModelBase, IPageViewModel
{
    private readonly IAuthConfiguration _auth;
    private readonly IAuthService _authService;
    private string _password;
    private string _userName;

    public LoginViewModel(IAuthService service)
    {
        //todo: configure options
        _auth = null;
        _authService = service;

        LoginCommand = new AsyncRelayCommand(Login, CanLogin);
    }

    public string UserName
    {
        get => _userName;
        set
        {
            SetProperty(ref _userName, value);
            LoginCommand.NotifyCanExecuteChanged();
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            SetProperty(ref _password, value);
            LoginCommand.NotifyCanExecuteChanged();
        }
    }

    public AsyncRelayCommand LoginCommand { get; }
    private async Task Login()
    {
        var user = await _authService.Login(UserName, Password);
        //todo: save this state somehow or send message
    }

    private bool CanLogin()
    {
        return UserName is not null && Password is not null ? true : false;
    }
}