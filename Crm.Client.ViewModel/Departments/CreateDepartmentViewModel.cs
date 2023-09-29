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
    private readonly IObservable<bool> _nameValidation;
    private ReactiveCommand<Unit, Department?> _createCommand;
    
    public CreateDepartmentViewModel(
        IDepartmentsService departmentsService,
        Department parent = null) : base(new ViewModelActivator())
    {
        _departmentsService = departmentsService;
        _parent = parent;
        _nameValidation = this.WhenAnyValue(x => x.Name, name => !string.IsNullOrWhiteSpace(name));
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

    public ReactiveCommand<Unit, Department> CreateCommand => _createCommand ??= 
        ReactiveCommand.CreateFromTask(async () => Result = await _departmentsService.Create(Name, Parent), 
            canExecute: _nameValidation);
    
    public bool? DialogResult { get; set; }


    public event EventHandler RequestClose;
    [RelayCommand]
    public void Cancel()
    {
        DialogResult = false;
        RequestClose?.Invoke(this, EventArgs.Empty);
    }
}
