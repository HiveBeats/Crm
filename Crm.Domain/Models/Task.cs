using System;

namespace Crm.Domain.Models;
public enum TaskState
{
    Todo = 0,
    InProgress = 1,
    Validation = 2,
    Done = 3
}

public class Task
{
    protected Task() { }
    public Task(Order order, Employee employee, string name, string description)
    {

        Id = Guid.NewGuid();
        Order = order;
        Employee = employee;
        Name = name;
        Description = description;
        State = TaskState.Todo;
    }

    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid EmployeeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public TaskState State { get; set; }

    public Order Order { get; set; }
    public Employee Employee { get; set; }

    public void ChangeState(TaskState state)
    {
        this.State = state;
    }
}
