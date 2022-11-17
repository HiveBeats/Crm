using Crm.Client.Application.Resource;
using Crm.Client.ViewModel.Common;
using Crm.Domain.Models;
using ReactiveUI;
using System.Collections.ObjectModel;
using Task = System.Threading.Tasks.Task;

namespace Crm.Client.ViewModel;
public class ResourcesViewModel : ViewModelBase
{
	private ObservableCollection<Resource> _items;
	private Resource _currentResource;
	private IResourceService _resourceService;
	public ResourcesViewModel(IResourceService resourceService) : base(new ReactiveUI.ViewModelActivator())
	{
		_resourceService = resourceService;
	}

	public ObservableCollection<Resource> Items
	{
		get => _items ?? (_items = new ObservableCollection<Resource>());
		set => this.RaiseAndSetIfChanged(ref _items, value);
	}

	public Resource CurrentResource
	{
		get => _currentResource;
		set => this.RaiseAndSetIfChanged(ref _currentResource, value);
	}

	protected override async Task HandleActivation()
	{
		Items = new ObservableCollection<Resource>(await _resourceService.GetAll());
	}
}
