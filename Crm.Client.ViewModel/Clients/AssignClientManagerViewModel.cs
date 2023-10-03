using Crm.Client.Application.Clients;
using Crm.Client.Application.Employees;
using Crm.Client.ViewModel.Common;
using Crm.Domain.Models;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using JetBrains.Annotations;

namespace Crm.Client.ViewModel.Clients;
public class AssignClientManagerViewModel : ViewModelBase
{
    private Domain.Models.Client _client;
    private ObservableCollection<Employee> _employees;
    private Employee _employee;
    private IReactiveCommand _assignCommand;
    private readonly IObservable<bool> _employeeValidation;
    private readonly IClientService _clientService;
    private readonly IEmployeeService _employeeService;
    
    public AssignClientManagerViewModel(Domain.Models.Client client, IClientService clientService, IEmployeeService employeeService) : base(new ViewModelActivator())
    {
        _clientService = clientService;
        _employeeService = employeeService;
        Client = client;
        _employeeValidation = this.WhenAnyValue<AssignClientManagerViewModel, bool, Employee>(x => x.Employee, emp => emp != null);
    }

    public ObservableCollection<Employee> Employees
    {
        get => _employees ??= new ObservableCollection<Employee>();
        set => SetProperty(ref _employees, value);
    }

    public Employee Employee
    {
        get => _employee;
        set => SetProperty(ref _employee, value);
    }

    [UsedImplicitly]
    public Domain.Models.Client Client
    {
        get => _client;
        set => SetProperty(ref _client, value);
    }

    public IReactiveCommand AssignCommand => _assignCommand ??= ReactiveCommand.CreateFromTask(async () =>
    {
        if (Employee == null)
        {
            throw new Exception("Employee should be defined!");
        }
        var client = await _clientService.GetById(Client.Id);
        var employee = await _employeeService.GetById(Employee.Id);

        await _clientService.AssignManager(client, employee);
    }, canExecute: _employeeValidation);

    protected override async void HandleActivation()
    {
        Employees = new ObservableCollection<Employee>(await _employeeService.GetAll());
    }
}
