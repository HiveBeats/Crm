namespace Crm.Domain.Models;
public class OrderResource
{
    public long Id { get; set; }
    public long ResourceId { get; set; }
    public long OrderId { get; set; }
    public decimal Amount { get; set; }

    public Resource Resource { get; set; }
    public Order Order { get; set; }

    public static OrderResource AssignResources(Order order, Resource resource, decimal amount)
    {
        resource.GetAmountOf(amount);

        return new OrderResource()
        {
            Order = order,
            Resource = resource,
            Amount = amount,
        };
    }
}
