
using Crm.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Crm.Infrastructure.Database;

public class CrmDbContext: DbContext
{
    public DbSet<Client> CLients { get; set; }
    public DbSet<ClientManager> ClientManagers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Resource> Resources { get; set; }
    
}