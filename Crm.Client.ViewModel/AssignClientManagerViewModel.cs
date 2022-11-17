using Crm.Client.Application.Client;
using Crm.Client.Application.Employee;
using Crm.Client.ViewModel.Common;
using Crm.Domain.Models;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;

namespace Crm.Client.ViewModel;
public class AssignClientManagerViewModel : ViewModelBase
{
	private Crm.Domain.Models.Client _client;
	private ObservableCollection<Employee> _employees;
	private Employee _employee;
	private IReactiveCommand _assignCommand;
	private IObservable<bool> _employeeValidation;
	private readonly IClientService _clientService;
	private readonly IEmployeeService _employeeService;
	public AssignClientManagerViewModel(Crm.Domain.Models.Client client, IClientService clientService, IEmployeeService employeeService) : base(new ViewModelActivator())
	{
		_clientService = clientService;
		_employeeService = employeeService;
		Client = client;

		_employeeValidation = this.WhenAnyValue<AssignClientManagerViewModel, bool, Employee>(x => x.Employee, emp => emp != null);
	}

	public ObservableCollection<Employee> Employees
	{
		get => _employees ?? (_employees = new ObservableCollection<Employee>());
		set => this.RaiseAndSetIfChanged(ref _employees, value);
	}

	public Employee Employee
	{
		get => _employee;
		set => this.RaiseAndSetIfChanged(ref _employee, value);
	}

	public Crm.Domain.Models.Client Client
	{
		get => _client;
		set => this.RaiseAndSetIfChanged(ref _client, value);
	}

	public IReactiveCommand AssignCommand => _assignCommand ?? (_assignCommand = ReactiveCommand.CreateFromTask(async () =>
	{
		if (Employee == null)
		{
			throw new System.Exception("Employee should be defined!");
		}
		var client = await _clientService.GetById(Client.Id);
		var employee = await _employeeService.GetById(Employee.Id);

		await _clientService.AssignManager(client, employee);
	}, canExecute: _employeeValidation));

	protected override async System.Threading.Tasks.Task HandleActivation()
	{
		Employees = new ObservableCollection<Employee>(await _employeeService.GetAll());
	}
}
