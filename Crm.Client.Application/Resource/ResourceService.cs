using Crm.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Crm.Client.Application.Resource;

public interface IResourceService
{
	Task<IReadOnlyCollection<Crm.Domain.Models.Resource>> GetAll();
	Task<Guid> Create(string name, decimal quantity);
}
public class ResourceService : IResourceService
{
	private CrmDbContext _dbContext;
	public ResourceService(CrmDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<Guid> Create(string name, decimal quantity)
	{
		var resource = new Crm.Domain.Models.Resource(name, quantity);
		_dbContext.Resources.Add(resource);
		await _dbContext.SaveChangesAsync();

		return resource.Id;
	}

	public async Task<IReadOnlyCollection<Domain.Models.Resource>> GetAll()
	{
		return await _dbContext.Resources.AsNoTracking().ToListAsync();
	}
}
