using System.Reactive.Concurrency;
using Crm.Client.Application.Employees;
using Crm.Client.ViewModel.Common;
using Crm.Domain.Models;
using ReactiveUI;

namespace Crm.Client.ViewModel.Employees;

public class EmployeeClientsViewModel : RelativeItemsViewModel<Employee, Domain.Models.Client>
{
    public EmployeeClientsViewModel(Employee employee, IEmployeeClientsService employeeClientsService)
    {
        OwnerItem = employee;
        ItemsService = employeeClientsService;
    }
}