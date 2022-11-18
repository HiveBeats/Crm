using Crm.Client.Application.Resources;
using Crm.Client.ViewModel.Common;
using Crm.Domain.Models;
using ReactiveUI;
using System.Reactive.Concurrency;

namespace Crm.Client.ViewModel.Resources;
public class ResourcesViewModel : ItemsViewModel<Resource>
{
    public ResourcesViewModel(IResourceService resourceService) : base(new ViewModelActivator())
    {
        _itemsService = resourceService;
        RxApp.MainThreadScheduler.ScheduleAsync(OnLoaded);
    }
}
