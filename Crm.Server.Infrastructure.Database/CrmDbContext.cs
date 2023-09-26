
using Crm.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using Npgsql.Logging;
using Task = Crm.Domain.Models.Task;

namespace Crm.Server.Infrastructure.Database;

public class CrmDbContext : DbContext
{
    public CrmDbContext(DbContextOptions options) : base(options){}

    public CrmDbContext()
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CrmDbContext).Assembly);
    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<ClientManager> ClientManagers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Resource> Resources { get; set; }
    public DbSet<OrderResource> OrderResources { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<AuditType> AuditTypes { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }
}