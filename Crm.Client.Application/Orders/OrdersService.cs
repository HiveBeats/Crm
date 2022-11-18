using Crm.Domain.Models;
using Crm.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Crm.Client.Application.Orders;
public interface IOrdersService : IItemsService<Order>
{
}
public class OrdersService :ServiceBase, IOrdersService
{
    public OrdersService(IDbContextFactory factory): base(factory)
    {
        
    }

    public async Task<IReadOnlyCollection<Order>> GetAll()
    {
        IReadOnlyCollection<Order> result;
        using (var db = GetDb())
        {
            result = await db.Orders.AsNoTracking().ToListAsync();
        }
        return result;
    }
}
