using Crm.Client.Application.Clients;
using Crm.Client.ViewModel.Common;
using ReactiveUI;
using Splat;
using System;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Windows.Input;

namespace Crm.Client.ViewModel.Clients;
public class ClientsViewModel : ItemsViewModel<Domain.Models.Client>, IPageViewModel
{
    public ClientsViewModel() : base(new ViewModelActivator())
    {
        _itemsService = Locator.Current.GetService<IClientService>();
        RxApp.MainThreadScheduler.ScheduleAsync(OnLoaded);

        ShowCreateOrderDialog = new Interaction<CreateClientOrderViewModel, Unit>();
        var createOrderValidation = this.WhenAny(x => x.CurrentItem, item => item != null);
        CreateOrderCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var vm = new CreateClientOrderViewModel(CurrentItem, Locator.Current.GetService<IClientOrdersService>());

            await ShowCreateOrderDialog.Handle(vm);
        }, canExecute: createOrderValidation);
    }
    public ICommand CreateOrderCommand { get; }
    public Interaction<CreateClientOrderViewModel, Unit> ShowCreateOrderDialog { get; }
}
