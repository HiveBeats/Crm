using Crm.Domain.Models;
using Crm.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Crm.Client.Application.Orders;
public interface IOrdersService : IItemsService<Order>
{
    Task<IReadOnlyCollection<Order>> GetAll();
}
public class OrdersService : IOrdersService
{
    private readonly CrmDbContext _db;

    public OrdersService(CrmDbContext db)
    {
        _db = db;
    }

    public async Task<IReadOnlyCollection<Order>> GetAll()
    {
        return await _db.Orders.AsNoTracking().ToListAsync();
    }
}
