using Microsoft.Extensions.DependencyInjection;

namespace Crm.Server.Infrastructure.Database;

public static class ServicesConfiguration
{
    public static void AddCrmServerService(this IServiceCollection services)
    {
        services.AddTransient<CrmDbContext>();
    }
}