using Crm.Domain.Models;
using Crm.Server.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Crm.Client.Application.Orders;
public interface IOrdersService : IItemsService<Order>
{
}
public class OrdersService: IOrdersService
{
    private readonly CrmDbContext _db;
    public OrdersService(CrmDbContext db)
    {
        _db = db;
    }

    public async Task<IReadOnlyCollection<Order>> GetAll()
    {
        IReadOnlyCollection<Order> result;
        result = await _db.Orders.AsNoTracking().ToListAsync();
        
        return result;
    }
}
