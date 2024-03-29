﻿using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using Crm.Client.Application.Clients;
using Crm.Client.Application.Employees;
using Crm.Client.ViewModel.Common;
using Crm.Domain.Models;
using JetBrains.Annotations;
using Task = System.Threading.Tasks.Task;

namespace Crm.Client.ViewModel.Clients;

public class AssignClientManagerViewModel : ViewModelBase, IOwned<Domain.Models.Client>
{
    private readonly IClientService _clientService;
    private readonly IEmployeeService _employeeService;
    private Domain.Models.Client _client;
    private Employee _employee;
    private ObservableCollection<Employee> _employees;

    public AssignClientManagerViewModel(IClientService clientService,
        IEmployeeService employeeService)
    {
        _clientService = clientService;
        _employeeService = employeeService;
        AssignCommand = new AsyncRelayCommand(Assign, CanAssign);
    }

    public ObservableCollection<Employee> Employees
    {
        get => _employees ??= new ObservableCollection<Employee>();
        set => SetProperty(ref _employees, value);
    }

    public Employee Employee
    {
        get => _employee;
        set
        {
            SetProperty(ref _employee, value);
            AssignCommand.NotifyCanExecuteChanged();
        }
    }

    [UsedImplicitly]
    public Domain.Models.Client Client
    {
        get => _client;
        set => SetProperty(ref _client, value);
    }
    
    public AsyncRelayCommand AssignCommand { get; }
    
    private async Task Assign()
    {
        if (Employee == null) throw new Exception("Employee should be defined!");
        var client = await _clientService.GetById(Client.Id);
        var employee = await _employeeService.GetById(Employee.Id);
        
        await _clientService.AssignManager(client, employee);
    }

    private bool CanAssign()
    {
        return Employee is not null ? true : false;
    }

    public override async Task InitAsync()
    {
        Employees = new ObservableCollection<Employee>(await _employeeService.GetAll());
    }

    public async Task InitFromOwnerAsync(Domain.Models.Client ownerItem)
    {
        Client = ownerItem;
        await InitAsync();
    }
}