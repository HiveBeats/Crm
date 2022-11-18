using System;
using System.Collections.Generic;
using System.Linq;

namespace Crm.Domain.Models;

public enum OrderState
{
    Todo = 0,
    InProgress = 1,
    Done = 2
}

public class Order: IEntity
{
    protected Order() { }
    public Order(Client client, string name, string description)
    {
        Id = Guid.NewGuid();
        ClientId = client.Id;
        Name = name;
        Description = description;
        State = OrderState.Todo;
    }

    public Guid Id { get; set; }
    public Guid ClientId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public OrderState State { get; set; }

    public Client Client { get; set; }
    public ICollection<Task> Tasks { get; set; }
    public ICollection<OrderResource> Resources { get; set; }

    public void ChangeState(OrderState state)
    {
        if (state == OrderState.Done && Tasks.Any(x => x.State != TaskState.Done))
        {
            throw new InvalidOperationException("Can't close order with undone tasks!");
        }
        this.State = state;
    }

    public void AddResource(Resource resource, decimal amount)
    {
        var orderResource = OrderResource.AssignResources(this, resource, amount);
        Resources.Add(orderResource);
    }
}