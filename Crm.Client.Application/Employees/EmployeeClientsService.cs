using Crm.Domain.Models;
using Crm.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Crm.Client.Application.Employees;
public interface IEmployeeClientsService : IRelativeItemsService<Employee, Domain.Models.Client>
{

}
public class EmployeeClientsService : IEmployeeClientsService
{
    private readonly CrmDbContext _dbContext;
    public EmployeeClientsService(CrmDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IReadOnlyCollection<Domain.Models.Client>> GetAll(Employee item)
    {
        return await _dbContext.ClientManagers
            .Include(x => x.Client)
            .Where(x => x.EmployeeId == item.Id)
            .AsNoTracking()
            .Select(x => x.Client)
            .ToListAsync();
    }
}
