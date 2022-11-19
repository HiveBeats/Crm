using Crm.Domain.Models;
using Crm.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Crm.Client.Application.Departments;
public interface IDepartmentsService:IItemsService<Department>
{
    Task<Department> Create(string name, Department parent = null);
}
public class DepartmentsService : ServiceBase, IDepartmentsService
{
    public DepartmentsService(IDbContextFactory dbContextFactory) : base(dbContextFactory)
    {
    }

    public async Task<IReadOnlyCollection<Department>> GetAll()
    {
        IReadOnlyCollection<Department> result;
        using (var db = GetDb())
        {
            result = await db.Departments.ToListAsync();
            //todo: https://stackoverflow.com/questions/57873786/ef-core-load-tree-list
        }
        return result;
    }

    public async Task<Department> Create(string name, Department parent = null)
    {
        Department result;
        using (var db = GetDb())
        {
            var department = new Department(name, parent);
            db.Departments.Add(department);
            await db.SaveChangesAsync();

            result = department;
        }

        return result;
    }
}
