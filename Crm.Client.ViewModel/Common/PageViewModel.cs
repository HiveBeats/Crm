using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Crm.Client.ViewModel.Common;

public class PageViewModel<T, TDetail> : ViewModelBase, IPageViewModel
    where T : ViewModelBase, IPageViewModel, IItemViewModel
    where TDetail : ViewModelBase
{
    private TDetail _detailViewModel;
    private T _masterViewModel;
    protected InitializableViewModelFactory _factory;

    protected PageViewModel(InitializableViewModelFactory factory)
    {
        _factory = factory;
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

    public override Task InitAsync()
    {
        return Task.CompletedTask;
    }
}