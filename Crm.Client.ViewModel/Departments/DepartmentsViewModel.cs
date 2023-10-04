using System.Reactive.Concurrency;
using CommunityToolkit.Mvvm.Input;
using Crm.Client.Application.Departments;
using Crm.Client.ViewModel.Common;
using Crm.Domain.Models;
using HanumanInstitute.MvvmDialogs;
using JetBrains.Annotations;
using ReactiveUI;
using Task = System.Threading.Tasks.Task;

namespace Crm.Client.ViewModel.Departments;

[UsedImplicitly]
public partial class DepartmentsViewModel : ItemsViewModel<Department>, IPageViewModel
{
    private readonly IDepartmentsService _departmentsService;
    private readonly IDialogService _dialogService;
    private readonly MainWindowViewModel _mainWindowViewModel;

    public DepartmentsViewModel(
        IDepartmentsService service,
        IDialogService dialogService,
        MainWindowViewModel mainWindowViewModel,
        IDepartmentsService departmentsService)
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
        if (result == true) Items.Add(dialogViewModel.Result);
    }
}