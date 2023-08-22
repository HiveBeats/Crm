using AutoMapper;
using Crm.Client.Application;
using Crm.Client.Application.Clients;
using Crm.Client.Application.Resources;
using Crm.Client.ViewModel.Clients;
using Crm.Client.ViewModel.Common;
using Crm.Infrastructure.Database;
using Microsoft.EntityFrameworkCore.Internal;
using Splat;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Crm.Client.ViewModel;
public static class Bootstrapper
{
    private static DbContextFactory InjectDbContextFactory()
    {
        var connection = "Host=178.250.156.227;Username=crm;Password=uoQutsHtrFLyLjKw;Database=crm;";
        var factory = new DbContextFactory(connection);
        Locator.CurrentMutable.RegisterConstant<IDbContextFactory>(factory);
        using (var db = factory.Create())
        {
            db.Database.Migrate();
        }
        return factory;
    }

    private static void InjectDatabaseServices(IDbContextFactory dbContextFactory)
    {
        var assembly = typeof(ServiceBase).Assembly;
        var services = (from assemblyType in assembly.GetExportedTypes()
                          where assemblyType.GetInterface(nameof(IDatabaseService)) != null
                          select assemblyType)
                          .ToArray();

        foreach (var svc in services)
        {
            foreach (var ifc in svc.GetInterfaces())
            {
                Locator.CurrentMutable.Register(() => Activator.CreateInstance(svc, dbContextFactory), ifc);
            }
        }
    }

    public static void InjectServices()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Domain.Models.Client, ClientDto>();
        });
        var mapper = new Mapper(configuration);
        Locator.CurrentMutable.RegisterConstant<IMapper>(new Mapper(configuration));

        var dbContextFactory = InjectDbContextFactory();
        InjectDatabaseServices(dbContextFactory);
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
