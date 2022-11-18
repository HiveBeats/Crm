using Crm.Infrastructure.Database;

namespace Crm.Client.Application;
public class ServiceBase
{
	protected readonly IDbContextFactory _dbContextFactory;
	public ServiceBase(IDbContextFactory dbContextFactory)
	{
		_dbContextFactory = dbContextFactory;
	}

	protected CrmDbContext GetDb()
	{
		return _dbContextFactory.Create();
	}
}
