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
using CommunityToolkit.Mvvm.Input;
using HanumanInstitute.MvvmDialogs;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Task = System.Threading.Tasks.Task;

namespace Crm.Client.ViewModel.Departments;

[UsedImplicitly]
public partial class DepartmentsViewModel : ItemsViewModel<Department>, IPageViewModel
{
    private IDialogService _dialogService;
    private MainWindowViewModel _mainWindowViewModel;
    private IDepartmentsService _departmentsService;
    
    public DepartmentsViewModel(
        IDepartmentsService service, 
        IDialogService dialogService, 
        MainWindowViewModel mainWindowViewModel,
        IDepartmentsService departmentsService) : base()
    {
        ItemsService = service;
        _dialogService = dialogService;
        _mainWindowViewModel = mainWindowViewModel;
        _departmentsService = departmentsService;
        RxApp.MainThreadScheduler.ScheduleAsync(OnLoaded);
    }

    [RelayCommand]
    private async Task Create()
    {
        var dialogViewModel = new CreateDepartmentViewModel(_departmentsService, CurrentItem);
        var result = await _dialogService.ShowDialogAsync(_mainWindowViewModel, dialogViewModel);
        if (result == true)
        {
            Items.Add(dialogViewModel.Result);
        }
    }
}