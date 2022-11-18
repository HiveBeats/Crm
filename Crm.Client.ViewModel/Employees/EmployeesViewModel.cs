using Crm.Client.Application.Employees;
using Crm.Client.ViewModel.Common;
using Crm.Domain.Models;
using ReactiveUI;
using System.Reactive.Concurrency;

namespace Crm.Client.ViewModel.Employees;
public class EmployeesViewModel : ItemsViewModel<Employee>
{
	public EmployeesViewModel(IEmployeeService employeeService) : base(new ReactiveUI.ViewModelActivator())
	{
		_itemsService = employeeService;
        RxApp.MainThreadScheduler.ScheduleAsync(OnLoaded);
    }
}
