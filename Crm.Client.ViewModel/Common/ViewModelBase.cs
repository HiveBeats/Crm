using System.Reactive.Concurrency;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Crm.Client.ViewModel.Common;

public class ViewModelBase : ObservableObject, IInitializableViewModel
{
    protected ViewModelBase()
    {
    }

    protected virtual async Task OnLoaded(IScheduler arg1, CancellationToken arg2)
    {
        await Task.CompletedTask;
    }

    public virtual async Task InitAsync()
    {
        throw new System.NotImplementedException();
    }
}