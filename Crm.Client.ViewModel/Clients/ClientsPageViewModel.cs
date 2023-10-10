using Crm.Client.ViewModel.Common;
using JetBrains.Annotations;

namespace Crm.Client.ViewModel.Clients;

[UsedImplicitly]
public class ClientsPageViewModel : PageViewModel<ClientsViewModel, ClientOrdersViewModel>
{
    public ClientsPageViewModel(InitializableViewModelFactory factory): base(factory)
    {
        MasterViewModel.MasterChanged += (s, e) =>
        {
            DetailViewModel = _factory.Create<ClientOrdersViewModel, Domain.Models.Client>((s as ClientsViewModel).CurrentItem);
        };
    }
}