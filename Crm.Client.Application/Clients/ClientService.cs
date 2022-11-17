using Crm.Domain.Models;
using Crm.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace Crm.Client.Application.Clients;
public interface IClientService : IItemsService<Crm.Domain.Models.Client>
{
    Task<IReadOnlyCollection<Crm.Domain.Models.Client>> GetAll();
    Task<Crm.Domain.Models.Client> GetById(Guid id);
    Task<Guid> Create(string name, string contact);
    Task<bool> AssignManager(Crm.Domain.Models.Client client, Crm.Domain.Models.Employee employee);
}
public class ClientService : IClientService
{
    private readonly CrmDbContext _dbContext;
    public ClientService(CrmDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> AssignManager(Domain.Models.Client client, Domain.Models.Employee employee)
    {
        var relation = ClientManager.Assign(client, employee);
        _dbContext.ClientManagers.Add(relation);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<Guid> Create(string name, string contact)
    {
        var client = new Crm.Domain.Models.Client(name, contact);
        _dbContext.Clients.Add(client);
        await _dbContext.SaveChangesAsync();

        return client.Id;
    }

    public async Task<IReadOnlyCollection<Crm.Domain.Models.Client>> GetAll()
    {
        var clientsWithManagers = await _dbContext.ClientManagers
            .Include(x => x.Client)
            .Include(x => x.Employee)
            .AsNoTracking()
            .ToListAsync();

        return (IReadOnlyCollection<Crm.Domain.Models.Client>)clientsWithManagers.Select(x =>
        {
            x.Client.Manager = x.Employee;
            return x.Client;
        });
    }

    public Task<Domain.Models.Client> GetById(Guid id)
    {
        return _dbContext.Clients.FirstAsync(x => x.Id == id);
    }
}


public class MockClientService : IClientService
{
    public async Task<bool> AssignManager(Domain.Models.Client client, Employee employee)
    {
        return await Task.FromResult(true);
    }

    public async Task<Guid> Create(string name, string contact)
    {
        return await Task.FromResult(Guid.NewGuid());
    }

    public async Task<IReadOnlyCollection<Domain.Models.Client>> GetAll()
    {
        var list = new List<Domain.Models.Client>()
        {
            new Domain.Models.Client("Irina Victorovna", "+79455684645"),
            new Domain.Models.Client("Alexander Ivanovich", "ivanovich.a@mail.ru")
        };

        await Task.Delay(2500);

        return await Task.FromResult(list);
    }

    public async Task<Domain.Models.Client> GetById(Guid id)
    {
        return await Task.FromResult(new Domain.Models.Client("Irina Victorovna", "+79455684645"));
    }
}