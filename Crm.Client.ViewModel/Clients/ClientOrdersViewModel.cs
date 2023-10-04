﻿using System.Reactive.Concurrency;
using Crm.Client.Application.Clients;
using Crm.Client.ViewModel.Common;
using Crm.Domain.Models;
using ReactiveUI;

namespace Crm.Client.ViewModel.Clients;

public class ClientOrdersViewModel : RelativeItemsViewModel<Domain.Models.Client, Order>
{
    public ClientOrdersViewModel(Domain.Models.Client client, IClientOrdersService clientOrdersService)
    {
        OwnerItem = client;
        ItemsService = clientOrdersService;
        RxApp.MainThreadScheduler.ScheduleAsync(OnLoaded);
    }
}