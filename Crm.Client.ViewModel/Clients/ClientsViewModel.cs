using Crm.Client.Application.Clients;
using Crm.Client.ViewModel.Common;
using ReactiveUI;
using Splat;
using System.Reactive.Concurrency;

namespace Crm.Client.ViewModel.Clients;
public class ClientsViewModel : ItemsViewModel<Domain.Models.Client>, IPageViewModel
{
    public ClientsViewModel() : base(new ViewModelActivator())
    {
        _itemsService = Locator.Current.GetService<IClientService>();
        RxApp.MainThreadScheduler.ScheduleAsync(OnLoaded);
    }
}
