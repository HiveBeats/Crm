using System;
using System.Collections.Generic;

namespace Crm.Domain.Models;

public class Employee:IEntity
{
    protected Employee() { }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Contact { get; set; }
    public Guid DepartmentId { get; set; }

    public Department Department { get; set; }
    public ICollection<Task> Tasks { get; set; }

    public static (Employee, string) CreateEmployee(string name, string contact, string email, Department department)
    {
        Employee employee = new Employee()
        {
            Id = Guid.NewGuid(),
            Name = name,
            Contact = contact,
            Department = department
        };

        var (user, password) = User.CreateForEmployee(employee, email);

        return (employee, password);
    }

    public void ChangeDepartment(Department department)
    {
        Department = department;
    }
}