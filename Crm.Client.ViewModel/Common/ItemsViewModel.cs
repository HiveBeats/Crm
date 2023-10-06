using System;
using System.Collections.ObjectModel;
using System.Reactive.Concurrency;
using System.Threading;
using System.Threading.Tasks;
using Crm.Client.Application;
using Crm.Domain;
using JetBrains.Annotations;

namespace Crm.Client.ViewModel.Common;

public interface IItemViewModel
{
    IEntity CurrentItem { get; }
}

public class ItemsViewModelBase<T> : ViewModelBase, IItemViewModel
    where T : class, IEntity
{
    private T _currentItem;
    private ObservableCollection<T> _items = new();

    protected ItemsViewModelBase()
    {
    }

    [UsedImplicitly]
    public ObservableCollection<T> Items
    {
        get => _items; // ??= new ObservableCollection<T>();
        set => SetProperty(ref _items, value);
    }

    [UsedImplicitly]
    public T CurrentItem
    {
        get => _currentItem;
        set
        {
            SetProperty(ref _currentItem, value);
            OnMasterChanged();
        }
    }

    IEntity IItemViewModel.CurrentItem => CurrentItem;

    public event EventHandler MasterChanged;

    protected void OnMasterChanged()
    {
        MasterChanged?.Invoke(this, EventArgs.Empty);
    }
}

public class ItemsViewModel<T> : ItemsViewModelBase<T>
    where T : class, IEntity
{
    protected IItemsService<T> ItemsService;

    protected ItemsViewModel()
    {
    }

    protected override async Task OnLoaded(IScheduler arg1, CancellationToken arg2)
    {
        var items = await ItemsService.GetAll();
        Items = new ObservableCollection<T>(items);
    }
}

public class RelativeItemsViewModel<T, TRelative> : ItemsViewModelBase<TRelative>
    where T : class, IEntity
    where TRelative : class, IEntity
{
    protected IRelativeItemsService<T, TRelative> ItemsService;
    protected T OwnerItem;

    protected RelativeItemsViewModel()
    {
    }

    protected override async Task OnLoaded(IScheduler arg1, CancellationToken arg2)
    {
        Items = new ObservableCollection<TRelative>(await ItemsService.GetAll(OwnerItem));
    }
}