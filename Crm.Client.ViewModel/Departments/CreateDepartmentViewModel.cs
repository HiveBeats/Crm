using Crm.Client.Application.Departments;
using Crm.Client.ViewModel.Common;
using Crm.Domain.Models;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
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
        OkCommand = new RelayCommand(Create);
    }

    public string Name
    {
        get => _name; 
        set => SetProperty(ref _name, value);
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
        if (!string.IsNullOrWhiteSpace(Name))
        {
            DialogResult = true;
            Result = await _departmentsService.Create(Name, Parent);
            RequestClose?.Invoke(this, EventArgs.Empty);
        }
    }

    public event EventHandler RequestClose;
    [RelayCommand]
    public void Cancel()
    {
        DialogResult = false;
        RequestClose?.Invoke(this, EventArgs.Empty);
    }
}
