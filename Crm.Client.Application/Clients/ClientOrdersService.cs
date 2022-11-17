using Crm.Domain.Models;
using Crm.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Crm.Client.Application.Clients;
public interface IClientOrdersService : IRelativeItemsService<Domain.Models.Client, Order>
{
    Task<Guid> Create(Crm.Domain.Models.Client client, string name, string description);
    Task<IReadOnlyCollection<Order>> GetClientOrders(Crm.Domain.Models.Client client);
}
public class ClientOrdersService : IClientOrdersService
{
    private readonly CrmDbContext _dbContext;
    public ClientOrdersService(CrmDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Create(Domain.Models.Client client, string name, string description)
    {
        var retrievedClient = await _dbContext.Clients.FindAsync(client.Orders);
        var order = new Order(retrievedClient, name, description);
        _dbContext.Orders.Add(order);
        await _dbContext.SaveChangesAsync();

        return order.Id;
    }

    public async Task<IReadOnlyCollection<Order>> GetAll(Domain.Models.Client item) => await GetClientOrders(item);

    public async Task<IReadOnlyCollection<Order>> GetClientOrders(Crm.Domain.Models.Client client)
    {
        return await _dbContext.Orders
            .Where(x => x.ClientId == client.Id)
            .AsNoTracking()
            .ToListAsync();
    }
}
