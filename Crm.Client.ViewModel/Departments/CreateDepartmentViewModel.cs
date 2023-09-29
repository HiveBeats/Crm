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
using HanumanInstitute.MvvmDialogs;

namespace Crm.Client.ViewModel.Departments;
public class CreateDepartmentViewModel : ViewModelBase, IModalDialogViewModel
{
    private readonly IDepartmentsService _departmentsService;
    private string _name;
    private Department _parent;
    private readonly IObservable<bool> _nameValidation;
    private ReactiveCommand<Unit, Department?> _createCommand;
    
    public CreateDepartmentViewModel(IDepartmentsService departmentsService, Department parent = null) : base(new ViewModelActivator())
    {
        _departmentsService = departmentsService;
        _parent = parent;
        _nameValidation = this.WhenAnyValue(x => x.Name, name => !string.IsNullOrWhiteSpace(name));
        CancelCommand = ReactiveCommand.Create(() => { });
    }

    public string Name
    {
        get => _name; 
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    public Department Parent
    {
        get => _parent;
        set => this.RaiseAndSetIfChanged(ref _parent, value);
    }
    
    public Department Result { get; set; }

    public ReactiveCommand<Unit, Department> CreateCommand => _createCommand ??= 
        ReactiveCommand.CreateFromTask(async () => Result = await _departmentsService.Create(Name, Parent), 
            canExecute: _nameValidation);

    public ReactiveCommand<Unit, Unit> CancelCommand { get; }
    public bool? DialogResult => Result != null;
}
