namespace Crm.Client.Application;
public interface IItemsService<T>
    where T : class
{
    Task<IReadOnlyCollection<T>> GetAll();
}

public interface IRelativeItemsService<T, TRelation>
    where T : class
    where TRelation : class
{
    Task<IReadOnlyCollection<TRelation>> GetAll(T item);
}
