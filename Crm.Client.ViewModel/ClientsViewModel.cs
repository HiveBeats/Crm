using Crm.Client.Application.Client;
using Crm.Client.ViewModel.Common;
using ReactiveUI;
using System.Collections.ObjectModel;

namespace Crm.Client.ViewModel;
public class ClientsViewModel : ViewModelBase
{
    private ObservableCollection<Crm.Domain.Models.Client> _items;
    private Crm.Domain.Models.Client _currentItem;
    private readonly IClientService _clientService;

    public ClientsViewModel(IClientService clientService) : base(new ViewModelActivator())
    {
        _clientService = clientService;
    }

    public ObservableCollection<Crm.Domain.Models.Client> Items
    {
        get => _items ?? (_items = new ObservableCollection<Domain.Models.Client>());
        set => this.RaiseAndSetIfChanged(ref _items, value);
    }
    public Crm.Domain.Models.Client CurrentItem
    {
        get => _currentItem;
        set => this.RaiseAndSetIfChanged(ref _currentItem, value);
    }

    protected override async System.Threading.Tasks.Task HandleActivation()
    {
        var clients = await _clientService.GetAll();
        Items = new ObservableCollection<Domain.Models.Client>(clients);
    }
}
