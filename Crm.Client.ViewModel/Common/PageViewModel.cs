using ReactiveUI;
using System;
using JetBrains.Annotations;

namespace Crm.Client.ViewModel.Common;
public class PageViewModel<T, TDetail>: ViewModelBase, IPageViewModel
	where T: ViewModelBase, IPageViewModel, IItemViewModel
	where TDetail: ViewModelBase
{
	private T _masterViewModel;
	private TDetail _detailViewModel;

	protected PageViewModel(): base(new ViewModelActivator())
	{
		//todo:
		//this.WhenAny(x => x.MasterViewModel.CurrentItem) ...
		MasterViewModel = System.Activator.CreateInstance<T>();
	}

	[UsedImplicitly]
	public T MasterViewModel 
	{ 
		get => _masterViewModel; 
		set => this.RaiseAndSetIfChanged(ref _masterViewModel, value); 
	}

	[UsedImplicitly]
	public TDetail DetailViewModel 
	{ 
		get => _detailViewModel; 
		set => this.RaiseAndSetIfChanged(ref _detailViewModel, value); 
	}
}
