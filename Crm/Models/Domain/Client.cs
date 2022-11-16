using System.Collections.Generic;

namespace Crm.Models.Domain;
public class Client
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Contact { get; set; }
    public ICollection<Order> Orders { get; set; }
}
