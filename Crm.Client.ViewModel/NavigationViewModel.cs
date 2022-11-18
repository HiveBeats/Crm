using Crm.Client.ViewModel.Clients;
using Crm.Client.ViewModel.Common;
using Crm.Client.ViewModel.Employees;
using Crm.Client.ViewModel.Resources;
using Splat;

namespace Crm.Client.ViewModel;

public class NavigationViewModel
{
	public NavigationViewModel()
	{
		ResourcesViewModel = Locator.Current.GetService<ResourcesViewModel>();
		EmployeesViewModel = Locator.Current.GetService<EmployeesViewModel>();
		ClientsViewModel = Locator.Current.GetService<ClientsViewModel>();
	}

	public ResourcesViewModel ResourcesViewModel { get; set; }
	public EmployeesViewModel EmployeesViewModel { get; set; }
	public ClientsViewModel ClientsViewModel { get; set; }
}
