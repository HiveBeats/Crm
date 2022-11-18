using AutoMapper;
using Crm.Client.Application.Clients;
using Crm.Client.Application.Resources;
using Crm.Client.ViewModel.Clients;
using Crm.Client.ViewModel.Common;
using Crm.Infrastructure.Database;
using Splat;
using System;
using System.Linq;

namespace Crm.Client.ViewModel;
public static class Bootstrapper
{
    private static DbContextFactory InjectDbContextFactory()
    {
        var connection = "Host=localhost;Username=john;Password=passw0rd;Database=todosdb;";
        var factory = new DbContextFactory(connection);
        Locator.CurrentMutable.RegisterConstant<IDbContextFactory>(factory);

        return factory;
    }

    public static void InjectServices()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Domain.Models.Client, ClientDto>();
        });
        var mapper = new Mapper(configuration);

        var dbContextFactory = InjectDbContextFactory();

        Locator.CurrentMutable.RegisterConstant<IMapper>(new Mapper(configuration));
        Locator.CurrentMutable.RegisterConstant<IClientService>(new ClientService(dbContextFactory));
    }

    public static void InjectViewModels()
    {
        var assembly = typeof(Bootstrapper).Assembly;

        var viewModels = (from assemblyType in assembly.GetExportedTypes()
                                where assemblyType.GetInterface(nameof(IPageViewModel)) != null
                                select assemblyType).ToArray();

        foreach (var vm in viewModels)
        {
            Locator.CurrentMutable.Register(() => Activator.CreateInstance(vm), vm);
        }
    }
}
