using Crm.Domain.Models;
using Crm.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Crm.Client.Application.Employees;
public interface IEmployeeService : IItemsService<Employee>
{
    Task<Employee> GetById(Guid id);
}
public class EmployeeService : ServiceBase, IEmployeeService
{
    public EmployeeService(IDbContextFactory dbContextFactory): base(dbContextFactory)
    {

    }

    public async Task<IReadOnlyCollection<Employee>> GetAll()
    {
        IReadOnlyCollection<Employee> result;
        using (var db = GetDb())
        {
            result =  await db.Employees.AsNoTracking().ToListAsync();
        }
        return result;
    }

    public async Task<Employee> GetById(Guid id)
    {
        Employee result;
        using (var db = GetDb())
        {
            result = await db.Employees.FirstAsync(x => x.Id == id);
        }

        return result;
    }
}
