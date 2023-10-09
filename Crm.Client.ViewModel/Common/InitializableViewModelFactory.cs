using Microsoft.Extensions.DependencyInjection;

namespace Crm.Client.ViewModel.Common;

public class InitializableViewModelFactory
{
    public void Create<TViewModel>()
    {
        var vm = (ViewModelBase)MainWindowViewModel.ServiceProvider.GetRequiredService(typeof(TViewModel));
        vm.InitAsync();
    }
}