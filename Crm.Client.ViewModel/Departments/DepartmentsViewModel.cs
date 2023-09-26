using Crm.Client.Application.Clients;
using Crm.Client.Application.Departments;
using Crm.Client.ViewModel.Clients;
using Crm.Client.ViewModel.Common;
using Crm.Domain.Models;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace Crm.Client.ViewModel.Departments;

[UsedImplicitly]
public class DepartmentsViewModel : ItemsViewModel<Department>, IPageViewModel
{
    public DepartmentsViewModel(IDepartmentsService service) : base(new ViewModelActivator())
    {
        ItemsService = service;
        RxApp.MainThreadScheduler.ScheduleAsync(OnLoaded);

        ShowCreateDialog = new Interaction<CreateDepartmentViewModel, Department>();
        CreateCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var vm = new CreateDepartmentViewModel(MainWindowViewModel.ServiceProvider.GetRequiredService<IDepartmentsService>(), CurrentItem);

            var result = await ShowCreateDialog.Handle(vm);
            if (result != null)
            {
                Items.Add(result);
            }
        });
    }

    public ICommand CreateCommand { get; }
    public Interaction<CreateDepartmentViewModel, Department> ShowCreateDialog { get; }
}
