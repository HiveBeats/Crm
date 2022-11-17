using Crm.Client.Application.Employees;
using Crm.Client.ViewModel.Common;
using Crm.Domain.Models;

namespace Crm.Client.ViewModel.Employees;
public class EmployeesViewModel : ItemsViewModel<Employee>
{
	public EmployeesViewModel(IEmployeeService employeeService) : base(new ReactiveUI.ViewModelActivator())
	{
		_itemsService = employeeService;
	}
}
