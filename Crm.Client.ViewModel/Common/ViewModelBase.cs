using System.Reactive.Concurrency;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Crm.Client.ViewModel.Common;
public class ViewModelBase : ObservableObject
{
    protected ViewModelBase(){ }

    protected virtual async Task OnLoaded(IScheduler arg1, CancellationToken arg2) { await Task.CompletedTask; }
}