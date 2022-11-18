using Crm.Client.Application.Clients;
using Crm.Client.ViewModel.Common;
using ReactiveUI;
using Splat;

namespace Crm.Client.ViewModel.Clients;
public class ClientsViewModel : ItemsViewModel<Domain.Models.Client>
{
    public ClientsViewModel(IClientService clientService = null) : base(new ViewModelActivator())
    {
        _itemsService = clientService ?? Locator.Current.GetService<IClientService>();
    }
}
