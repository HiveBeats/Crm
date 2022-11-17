using ReactiveUI;
using System.Reactive.Disposables;
using System.Threading.Tasks;

namespace Crm.Client.ViewModel.Common;
public class ViewModelBase : ReactiveObject, IActivatableViewModel
{
    public ViewModelBase(ViewModelActivator activator)
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

    protected virtual async Task HandleActivation() { await Task.CompletedTask; }

    protected virtual void HandleDeactivation() { }
}