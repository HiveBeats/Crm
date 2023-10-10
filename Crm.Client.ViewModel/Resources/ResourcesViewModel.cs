using System.Reactive.Concurrency;
using Crm.Client.Application.Resources;
using Crm.Client.ViewModel.Common;
using Crm.Domain.Models;
using JetBrains.Annotations;
using ReactiveUI;

namespace Crm.Client.ViewModel.Resources;

[UsedImplicitly]
public class ResourcesViewModel : ItemsViewModel<Resource>, IPageViewModel
{
    public ResourcesViewModel(IResourceService resourceService)
    {
        ItemsService = resourceService;
    }
}