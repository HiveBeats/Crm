using AutoMapper;
using Crm.Client.Application.Clients;
using Crm.Client.ViewModel.Clients;
using Crm.Client.ViewModel.Common;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Client.Avalonia;
public static class Bootstrapper
{
    public static void InjectServices()
    {   
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Domain.Models.Client, ClientDto>();
        });
        var mapper = new Mapper(configuration);
        Locator.CurrentMutable.RegisterConstant<IMapper>(new Mapper(configuration));
        Locator.CurrentMutable.RegisterConstant<IClientService>(new MockClientService());
    }

    public static void InjectViewModels()
    {
        Locator.CurrentMutable.RegisterConstant(new LoginViewModel());
        Locator.CurrentMutable.RegisterConstant(new ClientsViewModel());
    }
}
