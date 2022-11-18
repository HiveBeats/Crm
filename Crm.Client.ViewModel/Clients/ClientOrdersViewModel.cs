using Crm.Client.Application.Clients;
using Crm.Client.ViewModel.Common;
using Crm.Domain.Models;
using ReactiveUI;
using System.Reactive.Concurrency;

namespace Crm.Client.ViewModel.Clients;
public class ClientOrdersViewModel : RelativeItemsViewModel<Domain.Models.Client, Order>
{
	public ClientOrdersViewModel(Crm.Domain.Models.Client client, IClientOrdersService clientOrdersService) : base(new ReactiveUI.ViewModelActivator())
	{
		_ownerItem = client;
		_itemsService = clientOrdersService;
        RxApp.MainThreadScheduler.ScheduleAsync(OnLoaded);
    }
}
