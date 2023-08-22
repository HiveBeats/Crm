using Crm.Client.Application.Employees;
using Crm.Client.ViewModel.Common;
using Crm.Domain.Models;
using ReactiveUI;
using Splat;
using System.Reactive.Concurrency;

namespace Crm.Client.ViewModel.Employees;
public class EmployeesViewModel : ItemsViewModel<Employee>, IPageViewModel
{
	public EmployeesViewModel() : base(new ReactiveUI.ViewModelActivator())
	{
		ItemsService = Locator.Current.GetService<IEmployeeService>();
        RxApp.MainThreadScheduler.ScheduleAsync(OnLoaded);
    }
}
