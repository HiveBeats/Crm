using Crm.Domain.Models;
using Crm.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Crm.Client.Application.Employees;
public interface IEmployeeService : IItemsService<Employee>
{
    Task<IReadOnlyCollection<Crm.Domain.Models.Employee>> GetAll();
    Task<Crm.Domain.Models.Employee> GetById(Guid id);
}
public class EmployeeService : IEmployeeService
{
    private readonly CrmDbContext _dbContext;

    public EmployeeService(CrmDbContext crmDbContext)
    {
        _dbContext = crmDbContext;
    }

    public async Task<IReadOnlyCollection<Domain.Models.Employee>> GetAll()
    {
        return await _dbContext.Employees.AsNoTracking().ToListAsync();
    }

    public async Task<Domain.Models.Employee> GetById(Guid id)
    {
        return await _dbContext.Employees.FirstAsync(x => x.Id == id);
    }
}
