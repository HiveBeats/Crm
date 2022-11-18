
namespace Crm.Infrastructure.Database;
public interface IDbContextFactory
{
	CrmDbContext Create();
}
public class DbContextFactory: IDbContextFactory
{
	private readonly string _connectionString;
	public DbContextFactory(string connectionString)
	{
		_connectionString = connectionString;
	}

	public CrmDbContext Create()
	{
		return new CrmDbContext(_connectionString);
	}
}
