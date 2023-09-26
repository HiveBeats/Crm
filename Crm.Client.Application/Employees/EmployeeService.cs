using Crm.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Crm.Server.Infrastructure.Database;

namespace Crm.Client.Application.Employees;
public interface IEmployeeService : IItemsService<Employee>
{
    Task<Employee> GetById(Guid id);
}
public class EmployeeService : IEmployeeService
{
    private readonly CrmDbContext _db;
    public EmployeeService(CrmDbContext db)
    {
        _db = db;
    }

    public async Task<IReadOnlyCollection<Employee>> GetAll()
    {
        IReadOnlyCollection<Employee> result;
        result =  await _db.Employees.AsNoTracking().ToListAsync();
        
        return result;
    }

    public async Task<Employee> GetById(Guid id)
    {
        Employee result;
        result = await _db.Employees.FirstAsync(x => x.Id == id);
        

        return result;
    }
}
