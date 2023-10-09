using Crm.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Crm.Client.ViewModel.Common;

public class InitializableViewModelFactory
{
    public TViewModel Create<TViewModel>()
        where TViewModel : ViewModelBase
    {
        var vm = (TViewModel)MainWindowViewModel.ServiceProvider.GetRequiredService(typeof(TViewModel));
        vm.InitAsync();
        return vm;
    }

    public TViewModel Create<TViewModel, TModel, TRelativeModel>(TModel model)
        where TViewModel : ViewModelBase
        where TModel : class, IEntity
        where TRelativeModel : class, IEntity
    {
        var vm = MainWindowViewModel.ServiceProvider.GetService(typeof(TViewModel));
        ((RelativeItemsViewModel<TModel, TRelativeModel>)vm).OwnerItem = model;
        ((RelativeItemsViewModel<TModel, TRelativeModel>)vm).InitAsync();
        return (TViewModel)vm;
    }
}