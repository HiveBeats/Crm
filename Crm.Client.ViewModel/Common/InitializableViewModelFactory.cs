using Crm.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Crm.Client.ViewModel.Common;

public class InitializableViewModelFactory
{
    public TViewModel Create<TViewModel>()
        where TViewModel : ViewModelBase
    {
        var vm = (TViewModel)MainWindowViewModel.ServiceProvider.GetRequiredService(typeof(TViewModel));
        _ = vm.InitAsync();
        return vm;
    }

    public TViewModel Create<TViewModel, TModel>(TModel model)
        where TViewModel : ViewModelBase, IOwned<TModel>
        where TModel : class, IEntity
    {
        var vm = (TViewModel)MainWindowViewModel.ServiceProvider.GetRequiredService(typeof(TViewModel));
        _ = vm.InitFromOwnerAsync(model);
        return vm;
    }
}