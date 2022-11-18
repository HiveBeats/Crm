using Crm.Client.Application.Clients;
using Crm.Client.ViewModel.Common;
using ReactiveUI;
using Splat;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading;

namespace Crm.Client.ViewModel.Clients;
public class ClientsViewModel : ItemsViewModel<Domain.Models.Client>
{
    public ClientsViewModel(IClientService clientService = null) : base(new ViewModelActivator())
    {
        _itemsService = clientService ?? Locator.Current.GetService<IClientService>();
        RxApp.MainThreadScheduler.ScheduleAsync(OnLoaded);
    }
}
