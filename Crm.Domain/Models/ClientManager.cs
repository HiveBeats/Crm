using System;

namespace Crm.Domain.Models;
public class ClientManager: IEntity
{
    protected ClientManager() { }
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public Guid ClientId { get; set; }

    public Employee Employee { get; set; }
    public Client Client { get; set; }

    public static ClientManager Assign(Client client, Employee employee)
    {
        return new ClientManager()
        {
            Id = Guid.NewGuid(),
            Employee = employee,
            Client = client
        };
    }
}
