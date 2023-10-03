using Crm.Client.Application.Departments;
using Crm.Client.ViewModel.Common;
using Crm.Domain.Models;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HanumanInstitute.MvvmDialogs;

namespace Crm.Client.ViewModel.Departments;
public partial class CreateDepartmentViewModel : ViewModelBase, IModalDialogViewModel, ICloseable
{
    private readonly IDepartmentsService _departmentsService;
    private string _name;
    private Department _parent;
    
    public CreateDepartmentViewModel(
        IDepartmentsService departmentsService,
        Department parent = null) : base(new ViewModelActivator())
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
            this.CreateCommand.NotifyCanExecuteChanged();
        }
    }

    public Department Parent
    {
        get => _parent;
        set => SetProperty(ref _parent, value);
    }
    
    public Department Result { get; set; }
    public bool? DialogResult { get; set; }
    
    public RelayCommand CreateCommand { get; }
    private async void Create()
    {
        DialogResult = true;
        Result = await _departmentsService.Create(Name, Parent);
        RequestClose?.Invoke(this, EventArgs.Empty);
    }
    private bool CanCreate() => Name is null ? false : true;

    public event EventHandler RequestClose;
    [RelayCommand]
    public void Cancel()
    {
        DialogResult = false;
        RequestClose?.Invoke(this, EventArgs.Empty);
    }
}
