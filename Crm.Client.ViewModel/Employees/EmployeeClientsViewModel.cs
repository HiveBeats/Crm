using Crm.Client.Application.Employees;
using Crm.Client.ViewModel.Common;
using Crm.Domain.Models;
using ReactiveUI;
using System.Reactive.Concurrency;

namespace Crm.Client.ViewModel.Employees;
public class EmployeeClientsViewModel : RelativeItemsViewModel<Employee, Domain.Models.Client>
{
	public EmployeeClientsViewModel(Employee employee, IEmployeeClientsService employeeClientsService) : base(new ReactiveUI.ViewModelActivator())
	{
		OwnerItem = employee;
		ItemsService = employeeClientsService;
        RxApp.MainThreadScheduler.ScheduleAsync(OnLoaded);
    }
}
