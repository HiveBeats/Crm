using Crm.Client.Application.Resources;
using Crm.Client.ViewModel.Common;
using Crm.Domain.Models;
using ReactiveUI;
using Splat;
using System.Reactive.Concurrency;
using JetBrains.Annotations;

namespace Crm.Client.ViewModel.Resources;

[UsedImplicitly]
public class ResourcesViewModel : ItemsViewModel<Resource>, IPageViewModel
{
    public ResourcesViewModel() : base(new ViewModelActivator())
    {
        ItemsService = Locator.Current.GetService<IResourceService>();
        RxApp.MainThreadScheduler.ScheduleAsync(OnLoaded);
    }
}
