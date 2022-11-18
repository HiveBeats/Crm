using System;

namespace Crm.Domain.Models;
public class Resource
{
    protected Resource() { }
    public Resource(string name, decimal quantity = 0)
    {
        Id = Guid.NewGuid();
        Name = name;
        Quantity = quantity;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Quantity { get; set; }

    public void RemoveAmountOf(decimal amount)
    {
        if (Quantity < amount)
        {
            throw new InvalidOperationException("Not enough resources to assign");
        }

        Quantity -= amount;
    }

    public void AddAmountOf(decimal amount)
    {
        Quantity += amount;
    }
}
