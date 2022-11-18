using Crm.Infrastructure.Database;
using ReactiveUI;
using Splat;
using System.Reactive.Disposables;
using System.Threading.Tasks;

namespace Crm.Client.ViewModel.Common;
public class ViewModelBase : ReactiveObject, IActivatableViewModel
{
    private readonly IDbContextFactory _dbContextFactory;
    public ViewModelBase(ViewModelActivator activator)
    {
        _dbContextFactory = Locator.Current.GetService<IDbContextFactory>();
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