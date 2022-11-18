using Crm.Domain.Models;
using Crm.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Crm.Client.Application.Employees;
public interface IEmployeeClientsService : IRelativeItemsService<Employee, Domain.Models.Client>
{

}
public class EmployeeClientsService : ServiceBase, IEmployeeClientsService
{
    public EmployeeClientsService(IDbContextFactory factory): base(factory)
    {
    }
    public async Task<IReadOnlyCollection<Domain.Models.Client>> GetAll(Employee item)
    {
        IReadOnlyCollection<Domain.Models.Client> result;
        using (var db = GetDb())
        {
            result = await db.ClientManagers
                .Include(x => x.Client)
                .Where(x => x.EmployeeId == item.Id)
                .AsNoTracking()
                .Select(x => x.Client)
                .ToListAsync();
        }
        return result;
    }
}
