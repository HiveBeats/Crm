using Crm.Client.Application.Clients;
using Crm.Client.ViewModel.Common;
using ReactiveUI;

namespace Crm.Client.ViewModel.Clients;
public class ClientsViewModel : ItemsViewModel<Domain.Models.Client>
{
    public ClientsViewModel(IClientService clientService) : base(new ViewModelActivator())
    {
        _itemsService = clientService;
    }
}
