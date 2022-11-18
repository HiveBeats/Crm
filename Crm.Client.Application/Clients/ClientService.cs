using Crm.Domain.Models;
using Crm.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Task = System.Threading.Tasks.Task;

namespace Crm.Client.Application.Clients;
public interface IClientService : IItemsService<Crm.Domain.Models.Client>
{
    Task<IReadOnlyCollection<Crm.Domain.Models.Client>> GetAll();
    Task<Crm.Domain.Models.Client> GetById(Guid id);
    Task<Guid> Create(string name, string contact);
    Task<bool> AssignManager(Crm.Domain.Models.Client client, Crm.Domain.Models.Employee employee);
}
public class ClientService: ServiceBase, IClientService
{
    public ClientService(IDbContextFactory dbContextFactory): base(dbContextFactory)
    {
    }

    public async Task<bool> AssignManager(Domain.Models.Client client, Domain.Models.Employee employee)
    {
        bool result = false;
        using (var db = GetDb())
        {
            var relation = ClientManager.Assign(client, employee);
            db.ClientManagers.Add(relation);
            result = await db.SaveChangesAsync() > 0;
        }
        return result;
    }

    public async Task<Guid> Create(string name, string contact)
    {
        Guid result = Guid.Empty;
        using (var db = GetDb())
        {
            var client = new Crm.Domain.Models.Client(name, contact);
            db.Clients.Add(client);
            await db.SaveChangesAsync();
            result = client.Id;
        }

        return result;
    }

    public async Task<IReadOnlyCollection<Crm.Domain.Models.Client>> GetAll()
    {
        IReadOnlyCollection<Crm.Domain.Models.Client> result;
        using (var db = GetDb())
        {
            /*
            var clientsWithManagers = await db.ClientManagers
                .Include(x => x.Client)
                .Include(x => x.Employee)
                .AsNoTracking()
                .ToListAsync();
            */
            result = await db.Clients.AsNoTracking().ToListAsync();
            //result = (IReadOnlyCollection<Crm.Domain.Models.Client>)clientsWithManagers.Select(x =>
            //{
            //    x.Client.Manager = x.Employee;
            //    return x.Client;
            //});
        }
        return result;
    }

    public async Task<Domain.Models.Client> GetById(Guid id)
    {
        Domain.Models.Client result;
        using(var db = GetDb())
        {
            result = await db.Clients.FirstAsync(x => x.Id == id);
        }

        return result;
        
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