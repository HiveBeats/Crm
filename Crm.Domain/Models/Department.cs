using System;
using System.Collections.Generic;

namespace Crm.Domain.Models;

public class Department
{
    protected Department() { }
    public Department(string name, Department parent = null)
    {
        Id = Guid.NewGuid();
        Name = name;
        Parent = parent;
    }

    public Guid Id { get; set; }
    public Guid? ParentId { get; set; }
    public string Name { get; set; }

    public Department? Parent { get; set; }
    public ICollection<Employee> Employees { get; set; }
}