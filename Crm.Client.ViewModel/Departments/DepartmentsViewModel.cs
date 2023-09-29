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
using HanumanInstitute.MvvmDialogs;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace Crm.Client.ViewModel.Departments;

[UsedImplicitly]
public class DepartmentsViewModel : ItemsViewModel<Department>, IPageViewModel
{
    private IDialogService _dialogService;
    public DepartmentsViewModel(IDepartmentsService service, IDialogService dialogService) : base(new ViewModelActivator())
    {
        ItemsService = service;
        _dialogService = dialogService;
        RxApp.MainThreadScheduler.ScheduleAsync(OnLoaded);

        CreateCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var vm = new CreateDepartmentViewModel(MainWindowViewModel.ServiceProvider.GetRequiredService<IDepartmentsService>(), CurrentItem);
            var mainVm = MainWindowViewModel.ServiceProvider.GetRequiredService<MainWindowViewModel>();
            var result = await dialogService.ShowDialogAsync(mainVm, vm);
            if (result == true)
            {
                Items.Add(vm.Result);
            }
        });
    }

    public ICommand CreateCommand { get; }
}
