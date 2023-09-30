using Crm.Domain.Models;
using Crm.Server.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Crm.Client.Application.Departments;

public interface IDepartmentsService : IItemsService<Department>
{
    Task<Department> Create(string name, Department parent = null);
}

public class DepartmentsService : IDepartmentsService
{
    private readonly CrmDbContext _db;
    public DepartmentsService(CrmDbContext db) => _db = db;

    public async Task<IReadOnlyCollection<Department>> GetAll()
    {
        IReadOnlyCollection<Department> result;
        result = await _db.Departments.ToListAsync();
            //todo: https://stackoverflow.com/questions/57873786/ef-core-load-tree-list
        
        return result;
    }

    public async Task<Department> Create(string name, Department parent = null)
    {
        var department = new Department(name, parent);
        _db.Departments.Add(department);
        await _db.SaveChangesAsync();
        return department;
    }
}
