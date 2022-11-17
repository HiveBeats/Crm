using Crm.Client.Application.Clients;
using Crm.Client.ViewModel.Common;
using Crm.Domain.Models;

namespace Crm.Client.ViewModel.Clients;
public class ClientOrdersViewModel : RelativeItemsViewModel<Domain.Models.Client, Order>
{
	public ClientOrdersViewModel(Crm.Domain.Models.Client client, IClientOrdersService clientOrdersService) : base(new ReactiveUI.ViewModelActivator())
	{
		_ownerItem = client;
		_itemsService = clientOrdersService;
	}
}
