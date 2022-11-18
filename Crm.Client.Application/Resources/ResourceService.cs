using Crm.Domain.Models;
using Crm.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Crm.Client.Application.Resources;

public interface IResourceService:IItemsService<Resource>
{
	Task<Guid> Create(string name, decimal quantity);
}
public class ResourceService : ServiceBase, IResourceService
{
	public ResourceService(IDbContextFactory factory): base(factory)
	{
		
	}

	public async Task<Guid> Create(string name, decimal quantity)
	{
		Guid id = Guid.NewGuid();
		using (var db = GetDb())
		{
            var resource = new Crm.Domain.Models.Resource(name, quantity);

            db.Resources.Add(resource);
            await db.SaveChangesAsync();

            id = resource.Id;
        }
		

		return id;
	}

	public async Task<IReadOnlyCollection<Domain.Models.Resource>> GetAll()
	{
		IReadOnlyCollection<Domain.Models.Resource> result;
		using (var db = GetDb())
		{
			result = await db.Resources.AsNoTracking().ToListAsync();
        }
		return result;
	}
}
