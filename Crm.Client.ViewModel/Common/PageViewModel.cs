using JetBrains.Annotations;

namespace Crm.Client.ViewModel.Common;

public class PageViewModel<T, TDetail> : ViewModelBase, IPageViewModel
    where T : ViewModelBase, IPageViewModel, IItemViewModel
    where TDetail : ViewModelBase
{
    private TDetail _detailViewModel;
    private T _masterViewModel;

    protected PageViewModel()
    {
        //todo:
        //this.WhenAny(x => x.MasterViewModel.CurrentItem) ...
        MasterViewModel = (T)MainWindowViewModel.ServiceProvider.GetService(typeof(T));
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