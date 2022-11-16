using System.Collections.Generic;

namespace Crm.Models.Domain;

public class Employee
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Contact { get; set; }
    public long DepartmentId { get; set; }

    public Department Department { get; set; }
    public ICollection<Task> Tasks { get; set; }

    public static (Employee, string) CreateEmployee(string name, string contact, string email)
    {
        Employee employee = new Employee()
        {
            Name = name,
            Contact = contact,
            DepartmentId = 1 //todo: change to "DefaultDepartment" setting
        };

        var (user, password) = User.CreateForEmployee(employee, email);

        return (employee, password);
    }

    public void ChangeDepartment(Department department)
    {
        Department = department;
    }
}