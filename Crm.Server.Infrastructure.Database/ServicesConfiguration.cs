using Microsoft.Extensions.DependencyInjection;

namespace Crm.Server.Infrastructure.Database;

public static class ServicesConfiguration
{
    public static void AddDatabaseService(this IServiceCollection services)
    {
        services.AddTransient<CrmDbContext>();
    }
}