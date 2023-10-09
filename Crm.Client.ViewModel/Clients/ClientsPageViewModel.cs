using System;
using Crm.Client.Application.Clients;
using Crm.Client.ViewModel.Common;
using Crm.Domain;
using Crm.Domain.Models;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;

namespace Crm.Client.ViewModel.Clients;

[UsedImplicitly]
public class ClientsPageViewModel : PageViewModel<ClientsViewModel, ClientOrdersViewModel>
{
    public ClientsPageViewModel()
    {
        MasterViewModel.MasterChanged += (s, e) =>
        {
            DetailViewModel = _factory.Create<ClientOrdersViewModel, Domain.Models.Client, Order>((s as ClientsViewModel).CurrentItem);
        };
    }
}