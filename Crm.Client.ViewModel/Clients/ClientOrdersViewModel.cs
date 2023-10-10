using Crm.Client.Application.Clients;
using Crm.Client.ViewModel.Common;
using Crm.Domain.Models;

namespace Crm.Client.ViewModel.Clients;

public class ClientOrdersViewModel : RelativeItemsViewModel<Domain.Models.Client, Order>
{
    public ClientOrdersViewModel(IClientOrdersService clientOrdersService)
    {
        ItemsService = clientOrdersService;
    }
}