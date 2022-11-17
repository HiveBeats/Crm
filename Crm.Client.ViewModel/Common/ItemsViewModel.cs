using AutoMapper;
using Crm.Client.Application;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Linq;

namespace Crm.Client.ViewModel.Common;
public class ItemsViewModelBase<T> : ViewModelBase
	where T : class
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
}

public class ItemsViewModel<T, TDto> : ItemsViewModelBase<TDto>
	where T : class
	where TDto : class
{
	protected readonly IMapper _mapper;
	protected IItemsService<T> _itemsService;
	public ItemsViewModel(ViewModelActivator activator) : base(activator)
	{
		_mapper = Locator.Current.GetService<IMapper>();
	}
	protected override async System.Threading.Tasks.Task HandleActivation()
	{
		var items = await _itemsService.GetAll();		
        Items = new ObservableCollection<TDto>(items.Select(_mapper.Map<T, TDto>));
	}
}

public class RelativeItemsViewModel<T, TRelative> : ItemsViewModelBase<TRelative>
	where T : class
	where TRelative : class
{
	protected T _ownerItem;
	protected IRelativeItemsService<T, TRelative> _itemsService;
	public RelativeItemsViewModel(ViewModelActivator activator) : base(activator)
	{

	}
	protected override async System.Threading.Tasks.Task HandleActivation()
	{
		Items = new ObservableCollection<TRelative>(await _itemsService.GetAll(_ownerItem));
	}
}
