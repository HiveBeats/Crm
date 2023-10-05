using System.Threading.Tasks;
using System.Windows.Input;
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

        LoginCommand = ReactiveCommand.CreateFromTask(async () => { await Login(); });
    }

    public string UserName
    {
        get => _userName;
        set => SetProperty(ref _userName, value);
    }

    public string Password
    {
        get => _password;
        set => SetProperty(ref _password, value);
    }

    public ICommand LoginCommand { get; }

    private async Task Login()
    {
        var user = await _authService.Login(UserName, Password);
        //todo: save this state somehow or send message
    }
}