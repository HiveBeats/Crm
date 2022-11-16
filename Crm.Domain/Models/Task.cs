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
    public long Id { get; set; }
    public long OrderId { get; set; }
    public long EmployeeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public TaskState State { get; set; }

    public Order Order { get; set; }
    public Employee Employee { get; set; }

    public static Task CreateForOrder(Order order, Employee employee, string name, string description)
    {
        return new Task()
        {
            Order = order,
            Employee = employee,
            Name = name,
            Description = description,
            State = TaskState.Todo
        };
    }

    public void ChangeState(TaskState state)
    {
        this.State = state;
    }
}
