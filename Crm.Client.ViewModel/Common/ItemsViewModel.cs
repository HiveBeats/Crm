using Crm.Client.Application;
using Crm.Domain;
using DynamicData.Binding;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ReactiveUI;
using System.Collections;
using System.Collections.ObjectModel;
using System.Reactive.Concurrency;
using System.Threading;
using System.Threading.Tasks;

namespace Crm.Client.ViewModel.Common;
public interface IItemViewModel
{
	IEntity CurrentItem { get; }
}
public class ItemsViewModelBase<T> : ViewModelBase, IItemViewModel
	where T : class, IEntity
{
	private ObservableCollection<T> _items;
	private T _currentItem;
	public ItemsViewModelBase(ViewModelActivator activator) : base(activator)
	{

	}

	public ObservableCollection<T> Items
	{
		get => _items ?? (_items = new ObservableCollection<T>());
		set => this.RaiseAndSetIfChanged(ref _items, value);
	}

	public T CurrentItem
	{
		get => _currentItem;
		set => this.RaiseAndSetIfChanged(ref _currentItem, value);
	}

	IEntity IItemViewModel.CurrentItem => this.CurrentItem;
}

public class ItemsViewModel<T> : ItemsViewModelBase<T>
	where T : class, IEntity
{
	protected IItemsService<T> _itemsService;
	public ItemsViewModel(ViewModelActivator activator) : base(activator)
	{
        
    }

	protected override async Task OnLoaded(IScheduler arg1, CancellationToken arg2)
	{
        var items = await _itemsService.GetAll();
        Items = new ObservableCollection<T>(items);
    }
}

public class RelativeItemsViewModel<T, TRelative> : ItemsViewModelBase<TRelative>
	where T : class, IEntity
	where TRelative : class, IEntity
{
	protected T _ownerItem;
	protected IRelativeItemsService<T, TRelative> _itemsService;
	public RelativeItemsViewModel(ViewModelActivator activator) : base(activator)
	{

	}

    protected override async Task OnLoaded(IScheduler arg1, CancellationToken arg2)
    {
        Items = new ObservableCollection<TRelative>(await _itemsService.GetAll(_ownerItem));
    }
}
