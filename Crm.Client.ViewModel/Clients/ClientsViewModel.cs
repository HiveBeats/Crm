using Crm.Client.Application.Clients;
using Crm.Client.ViewModel.Common;
using ReactiveUI;
using Splat;
using System;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Crm.Client.ViewModel.Clients;
public class ClientsViewModel : ItemsViewModel<Domain.Models.Client>, IPageViewModel
{
    public ClientsViewModel() : base(new ViewModelActivator())
    {
        ItemsService = Locator.Current.GetService<IClientService>();
        RxApp.MainThreadScheduler.ScheduleAsync(OnLoaded);

        ShowCreateOrderDialog = new Interaction<CreateClientOrderViewModel, Unit>();
        
        var createOrderValidation = this
            .WhenAnyValue<ClientsViewModel, bool, Domain.Models.Client>(x => x.CurrentItem, 
                item => item!= null);
        
        CreateOrderCommand = ReactiveCommand.CreateFromTask(CreateClientOrderAsync, canExecute: createOrderValidation);
    }
    
    public ICommand CreateOrderCommand { get; }
    public Interaction<CreateClientOrderViewModel, Unit> ShowCreateOrderDialog { get; }

    private async Task CreateClientOrderAsync()
    {
        var vm = new CreateClientOrderViewModel(CurrentItem, Locator.Current.GetService<IClientOrdersService>());
        await ShowCreateOrderDialog.Handle(vm);
        OnMasterChanged();
    }
}
