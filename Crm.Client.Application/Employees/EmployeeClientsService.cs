using Crm.Domain.Models;
using Crm.Server.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Crm.Client.Application.Employees;
public interface IEmployeeClientsService : IRelativeItemsService<Employee, Domain.Models.Client>
{

}
public class EmployeeClientsService : IEmployeeClientsService
{
    private readonly CrmDbContext _db;
    public EmployeeClientsService(CrmDbContext db)
    {
        _db = db;
    }
    public async Task<IReadOnlyCollection<Domain.Models.Client>> GetAll(Employee item)
    {
        IReadOnlyCollection<Domain.Models.Client> result;
        result = await _db.ClientManagers
                .Include(x => x.Client)
                .Where(x => x.EmployeeId == item.Id)
                .AsNoTracking()
                .Select(x => x.Client)
                .ToListAsync();
        
        return result;
    }
}
