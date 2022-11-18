using Crm.Client.Application.Resources;
using Crm.Client.ViewModel.Common;
using Crm.Domain.Models;
using ReactiveUI;
using Splat;
using System.Reactive.Concurrency;

namespace Crm.Client.ViewModel.Resources;
public class ResourcesViewModel : ItemsViewModel<Resource>, IPageViewModel
{
    public ResourcesViewModel() : base(new ViewModelActivator())
    {
        _itemsService = Locator.Current.GetService<IResourceService>();
        RxApp.MainThreadScheduler.ScheduleAsync(OnLoaded);
    }
}
