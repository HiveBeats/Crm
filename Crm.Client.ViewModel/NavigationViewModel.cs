using Crm.Client.ViewModel.Clients;
using Crm.Client.ViewModel.Common;
using Crm.Client.ViewModel.Departments;
using Crm.Client.ViewModel.Resources;
using ReactiveUI;
using Splat;
using System.Reactive;

namespace Crm.Client.ViewModel;

public class NavigationViewModel:ViewModelBase, IPageViewModel
{
	private ViewModelBase _currentContext;
	private ReactiveCommand<string, Unit> _navigateCommand;
	public NavigationViewModel(): base(new ReactiveUI.ViewModelActivator())
	{
		ResourcesViewModel = Locator.Current.GetService<ResourcesViewModel>();
		DepartmentsViewModel = Locator.Current.GetService<DepartmentsViewModel>();
		ClientsViewModel = Locator.Current.GetService<ClientsPageViewModel>();

		CurrentContext = ClientsViewModel;
	}

	public ResourcesViewModel ResourcesViewModel { get; set; }
	public DepartmentsViewModel DepartmentsViewModel { get; set; }
	public ClientsPageViewModel ClientsViewModel { get; set; }

	public ViewModelBase CurrentContext 
	{ 
		get => _currentContext; 
		set => this.RaiseAndSetIfChanged(ref _currentContext, value); 
	}

	public ReactiveCommand<string, Unit> NavigateCommand => _navigateCommand ?? (_navigateCommand = ReactiveCommand.Create<string>((name) =>
	{
		switch(name)
		{
			case "Client":
				CurrentContext = ClientsViewModel;
				break;
			case "Resource":
				CurrentContext = ResourcesViewModel;
				break;
			case "Employee":
				CurrentContext = DepartmentsViewModel;
				break;
		}
	}));
}
