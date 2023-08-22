using Crm.Domain.Models;
using Crm.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Crm.Client.Application.Clients;
public interface IClientOrdersService : IRelativeItemsService<Domain.Models.Client, Order>
{
    Task<Guid> Create(Crm.Domain.Models.Client client, string name, string description);
    Task<IReadOnlyCollection<Order>> GetClientOrders(Crm.Domain.Models.Client client);
}
public class ClientOrdersService: ServiceBase, IClientOrdersService
{
    public ClientOrdersService(IDbContextFactory dbContextFactory): base(dbContextFactory)
    {    
    }

    public async Task<Guid> Create(Domain.Models.Client client, string name, string description)
    {
        if (client == null)
        {
            throw new ArgumentNullException(nameof(client));
        }
        
        Guid result = Guid.Empty;
        using(var db = GetDb())
        {
            var retrievedClient = await db.Clients.FirstAsync(c => c.Id == client.Id);
            var order = new Order(retrievedClient, name, description);
            db.Orders.Add(order);
            await db.SaveChangesAsync();
            result = order.Id;
        }

        return result;
    }

    public async Task<IReadOnlyCollection<Order>> GetAll(Domain.Models.Client item) => await GetClientOrders(item);

    public async Task<IReadOnlyCollection<Order>> GetClientOrders(Crm.Domain.Models.Client client)
    {
        IReadOnlyCollection<Order> orders;
        using (var db = GetDb())
        {
            orders = await db.Orders
                .Where(x => x.ClientId == client.Id)
                .AsNoTracking()
                .ToListAsync();
        }

        return orders;
    }
}
