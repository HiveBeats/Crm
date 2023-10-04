using System;
using CommunityToolkit.Mvvm.Input;
using Crm.Client.Application.Departments;
using Crm.Client.ViewModel.Common;
using Crm.Domain.Models;
using HanumanInstitute.MvvmDialogs;

namespace Crm.Client.ViewModel.Departments;

public partial class CreateDepartmentViewModel : ViewModelBase, IModalDialogViewModel, ICloseable
{
    private readonly IDepartmentsService _departmentsService;
    private string _name;
    private Department _parent;

    public CreateDepartmentViewModel(
        IDepartmentsService departmentsService,
        Department parent = null)
    {
        _departmentsService = departmentsService;
        _parent = parent;
        CreateCommand = new RelayCommand(Create, CanCreate);
    }

    public string Name
    {
        get => _name;
        set
        {
            SetProperty(ref _name, value);
            CreateCommand.NotifyCanExecuteChanged();
        }
    }

    public Department Parent
    {
        get => _parent;
        set => SetProperty(ref _parent, value);
    }

    public Department Result { get; set; }

    public RelayCommand CreateCommand { get; }

    public event EventHandler RequestClose;
    public bool? DialogResult { get; set; }

    private async void Create()
    {
        DialogResult = true;
        Result = await _departmentsService.Create(Name, Parent);
        RequestClose?.Invoke(this, EventArgs.Empty);
    }

    private bool CanCreate()
    {
        return Name is null ? false : true;
    }

    [RelayCommand]
    public void Cancel()
    {
        DialogResult = false;
        RequestClose?.Invoke(this, EventArgs.Empty);
    }
}