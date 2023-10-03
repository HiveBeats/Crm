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
        OkCommand = new RelayCommand(Create, CanOk);
    }


    public string Name
    {
        get => _name;
        set
        {
            SetProperty(ref _name, value);
            this.OkCommand.NotifyCanExecuteChanged();
        }
    }

    public Department Parent
    {
        get => _parent;
        set => SetProperty(ref _parent, value);
    }
    
    public Department Result { get; set; }
    public bool? DialogResult { get; set; }
    
    public RelayCommand OkCommand { get; }
    private async void Create()
    {
        DialogResult = true;
        Result = await _departmentsService.Create(Name, Parent);
        RequestClose?.Invoke(this, EventArgs.Empty);
    }
    private bool CanOk() => Name is null ? false : true;

    public event EventHandler RequestClose;
    [RelayCommand]
    public void Cancel()
    {
        DialogResult = false;
        RequestClose?.Invoke(this, EventArgs.Empty);
    }
}
