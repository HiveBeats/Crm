using AutoMapper;
using Crm.Client.Application.Clients;
using Crm.Client.ViewModel.Clients;
using Crm.Client.ViewModel.Common;
using Crm.Infrastructure.Database;
using Splat;

namespace Crm.Client.ViewModel;
public static class Bootstrapper
{
    private static void InjectDbContextFactory()
    {
        var connection = "Host=localhost;Username=john;Password=passw0rd;Database=todosdb;";
        var factory = new DbContextFactory(connection);
        Locator.CurrentMutable.RegisterConstant<IDbContextFactory>(factory);
    }

    public static void InjectServices()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Domain.Models.Client, ClientDto>();
        });
        var mapper = new Mapper(configuration);

        InjectDbContextFactory();
        Locator.CurrentMutable.RegisterConstant<IMapper>(new Mapper(configuration));
        Locator.CurrentMutable.RegisterConstant<IClientService>(new MockClientService());
    }

    public static void InjectViewModels()
    {
        Locator.CurrentMutable.RegisterConstant(new LoginViewModel());
        Locator.CurrentMutable.RegisterConstant(new ClientsViewModel());
    }
}
