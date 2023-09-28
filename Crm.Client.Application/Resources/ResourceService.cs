using Crm.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Crm.Server.Infrastructure.Database;

namespace Crm.Client.Application.Resources;

public interface IResourceService:IItemsService<Resource>
{
	Task<Guid> Create(string name, decimal quantity);
}
public class ResourceService : IResourceService
{
	private readonly CrmDbContext _db;
	public ResourceService(CrmDbContext db)
	{
		_db = db;
	}

	public async Task<Guid> Create(string name, decimal quantity)
	{
		Guid id = Guid.NewGuid();
		var resource = new Crm.Domain.Models.Resource(name, quantity);

        _db.Resources.Add(resource);
        await _db.SaveChangesAsync();

        id = resource.Id;
        
		

		return id;
	}

	public async Task<IReadOnlyCollection<Domain.Models.Resource>> GetAll()
	{
		IReadOnlyCollection<Domain.Models.Resource> result;
		result = await _db.Resources.AsNoTracking().ToListAsync();
		return result;
	}
}
