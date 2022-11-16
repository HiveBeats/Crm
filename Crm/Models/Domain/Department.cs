using System.Collections.Generic;

namespace Crm.Models.Domain;

public class Department
{
    public long Id { get; set; }
    public long? ParentId { get; set; }
    public string Name { get; set; }

    public Department? Parent { get; set; }
    public ICollection<Employee> Employees { get; set; }
}