using System.Collections.Generic;

namespace Crm.Domain.Models;
public class Client
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Contact { get; set; }
    public ICollection<Order> Orders { get; set; }
}
