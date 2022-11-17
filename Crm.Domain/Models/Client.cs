using System;
using System.Collections.Generic;

namespace Crm.Domain.Models;
public class Client
{
    public Client(string name, string contact)
    {
        Id = Guid.NewGuid();
        Name = name;
        Contact = contact;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Contact { get; set; }
    public ICollection<Order> Orders { get; set; }
}
