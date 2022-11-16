namespace Crm.Models.Domain;
public class ClientManager
{
    public long Id { get; set; }
    public long EmployeeId { get; set; }
    public long ClientId { get; set; }

    public Employee Employee { get; set; }
    public Client Client { get; set; }

    public static ClientManager Assign(Client client, Employee employee)
    {
        return new ClientManager()
        {
            Employee = employee,
            Client = client
        };
    }
}
