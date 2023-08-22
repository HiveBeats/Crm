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

namespace Crm.Client.ViewModel.Departments;
public class DepartmentsViewModel : ItemsViewModel<Department>, IPageViewModel
{
    public DepartmentsViewModel() : base(new ViewModelActivator())
    {
        ItemsService = Locator.Current.GetService<IDepartmentsService>();
        RxApp.MainThreadScheduler.ScheduleAsync(OnLoaded);

        ShowCreateDialog = new Interaction<CreateDepartmentViewModel, Department>();
        CreateCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var vm = new CreateDepartmentViewModel(Locator.Current.GetService<IDepartmentsService>(), CurrentItem);

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
