using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace Crm.Client.ViewModel.Common;

public class PageViewModel<T, TDetail> : ViewModelBase, IPageViewModel
    where T : ViewModelBase, IPageViewModel, IItemViewModel
    where TDetail : ViewModelBase
{
    private TDetail _detailViewModel;
    private T _masterViewModel;
    protected InitializableViewModelFactory _factory;

    protected PageViewModel()
    {
        _factory = MainWindowViewModel.ServiceProvider.GetRequiredService<InitializableViewModelFactory>();
        MasterViewModel = _factory.Create<T>();
    }

    [UsedImplicitly]
    public T MasterViewModel
    {
        get => _masterViewModel;
        set => SetProperty(ref _masterViewModel, value);
    }

    [UsedImplicitly]
    public TDetail DetailViewModel
    {
        get => _detailViewModel;
        set => SetProperty(ref _detailViewModel, value);
    }
}