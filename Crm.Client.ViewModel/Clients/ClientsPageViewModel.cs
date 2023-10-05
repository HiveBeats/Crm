﻿using System;
using Crm.Client.Application.Clients;
using Crm.Client.ViewModel.Common;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;

namespace Crm.Client.ViewModel.Clients;

[UsedImplicitly]
public class ClientsPageViewModel : PageViewModel<ClientsViewModel, ClientOrdersViewModel>
{
    public ClientsPageViewModel()
    {
        //todo: into master-detail VM?
        MasterViewModel.MasterChanged += (s, e) =>
        {
            DetailViewModel = new ClientOrdersViewModel((s as ClientsViewModel).CurrentItem,
                MainWindowViewModel.ServiceProvider.GetRequiredService<IClientOrdersService>());
        };

        this.WhenAnyValue(x => x.MasterViewModel.CurrentItem).Subscribe(x =>
        {
            DetailViewModel = new ClientOrdersViewModel(x,
                MainWindowViewModel.ServiceProvider.GetRequiredService<IClientOrdersService>());
        });
    }
}