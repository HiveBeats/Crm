using Crm.Client.Application.Resources;
using Crm.Client.ViewModel.Common;
using Crm.Domain.Models;
using ReactiveUI;

namespace Crm.Client.ViewModel.Resources;
public class ResourcesViewModel : ItemsViewModel<Resource>
{
    public ResourcesViewModel(IResourceService resourceService) : base(new ViewModelActivator())
    {
        _itemsService = resourceService;
    }
}
