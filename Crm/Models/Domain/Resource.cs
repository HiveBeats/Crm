using System;

namespace Crm.Models.Domain;
public class Resource
{
    public long Id { get; set; }
    public string Name { get; set; }
    public decimal Quantity { get; set; }

    public void GetAmountOf(decimal amount)
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
