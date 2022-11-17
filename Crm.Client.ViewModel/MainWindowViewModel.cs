using Crm.Client.ViewModel.Clients;
using Crm.Client.ViewModel.Common;
using Splat;

namespace Crm.Client.ViewModel;

public class MainWindowViewModel
{
	public MainWindowViewModel()
	{
		LoginViewModel = Locator.Current.GetService<LoginViewModel>();
		ClientsViewModel = Locator.Current.GetService<ClientsViewModel>();
	}


	public LoginViewModel LoginViewModel { get; set; }
	public ClientsViewModel ClientsViewModel { get; set; }
}
