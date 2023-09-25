using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Crm.Server.Infrastructure.Database;

public static class ServicesConfiguration
{
    public static void AddDatabaseServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<CrmDbContext>(option => option.UseNpgsql(connectionString));
    }
}