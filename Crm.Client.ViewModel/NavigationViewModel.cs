using Crm.Client.ViewModel.Clients;
using Crm.Client.ViewModel.Common;
using Crm.Client.ViewModel.Departments;
using Crm.Client.ViewModel.Resources;
using ReactiveUI;
using Splat;
using System.Reactive;
using JetBrains.Annotations;

namespace Crm.Client.ViewModel;

public class NavigationViewModel:ViewModelBase, IPageViewModel
{
	private ViewModelBase _currentContext;
	private ReactiveCommand<string, Unit> _navigateCommand;
	private readonly ResourcesViewModel _resourcesViewModel;
	private readonly DepartmentsViewModel _departmentsViewModel;
	private readonly ClientsPageViewModel _clientsViewModel;

	public NavigationViewModel(): base(new ReactiveUI.ViewModelActivator())
	{
		_resourcesViewModel = Locator.Current.GetService<ResourcesViewModel>();
		_departmentsViewModel = Locator.Current.GetService<DepartmentsViewModel>();
		_clientsViewModel = Locator.Current.GetService<ClientsPageViewModel>();

		CurrentContext = _clientsViewModel;
	}

	[UsedImplicitly]
	public ViewModelBase CurrentContext 
	{ 
		get => _currentContext; 
		set => this.RaiseAndSetIfChanged(ref _currentContext, value); 
	}

	[UsedImplicitly]
	public ReactiveCommand<string, Unit> NavigateCommand => _navigateCommand ??= ReactiveCommand.Create<string>((name) =>
	{
		CurrentContext = name switch
		{
			"Client" => _clientsViewModel,
			"Resource" => _resourcesViewModel,
			"Employee" => _departmentsViewModel,
			_ => CurrentContext
		};
	});
}
