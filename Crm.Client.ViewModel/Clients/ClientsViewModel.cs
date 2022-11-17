using Crm.Client.Application.Clients;
using Crm.Client.ViewModel.Common;
using ReactiveUI;
using Splat;
using System.Linq;
using System.Threading.Tasks;

namespace Crm.Client.ViewModel.Clients;
public class ClientsViewModel : ItemsViewModel<Domain.Models.Client, ClientDto>
{
    public ClientsViewModel(IClientService clientService = null) : base(new ViewModelActivator())
    {
        _itemsService = clientService ?? Locator.Current.GetService<IClientService>();
    }
}
