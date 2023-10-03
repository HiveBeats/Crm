using System.ComponentModel;
using ReactiveUI;
using Splat;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;

namespace Crm.Client.ViewModel.Common;
public class ViewModelBase : ObservableObject, IActivatableViewModel
{
    protected ViewModelBase(){ }
    
    protected ViewModelBase(ViewModelActivator activator)
    {
        Activator = activator;
        this.WhenActivated(disposables =>
        {
            // Use WhenActivated to execute logic
            // when the view model gets activated.
            this.HandleActivation();

            // Or use WhenActivated to execute logic
            // when the view model gets deactivated.
            Disposable
                .Create(() => this.HandleDeactivation())
                .DisposeWith(disposables);
        });
    }
    public ViewModelActivator Activator { get; }

    protected virtual void HandleActivation() { }

    protected virtual void HandleDeactivation() { }

    protected virtual async Task OnLoaded(IScheduler arg1, CancellationToken arg2) { await Task.CompletedTask; }
}