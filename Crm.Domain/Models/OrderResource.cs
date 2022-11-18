using System;

namespace Crm.Domain.Models;
public class OrderResource
{
    protected OrderResource() { }
    public Guid Id { get; set; }
    public Guid ResourceId { get; set; }
    public Guid OrderId { get; set; }
    public decimal Amount { get; set; }

    public Resource Resource { get; set; }
    public Order Order { get; set; }

    public static OrderResource AssignResources(Order order, Resource resource, decimal amount)
    {
        resource.RemoveAmountOf(amount);

        return new OrderResource()
        {
            Id = Guid.NewGuid(),
            Order = order,
            Resource = resource,
            Amount = amount,
        };
    }
}
