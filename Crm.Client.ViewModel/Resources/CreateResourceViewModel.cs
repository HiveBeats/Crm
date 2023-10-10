using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Crm.Client.Application.Resources;
using Crm.Client.ViewModel.Common;

namespace Crm.Client.ViewModel.Resources;

public class CreateResourceViewModel : ViewModelBase
{
    private readonly IResourceService _resourceService;
    private string _name;
    private decimal _quantity;

    public CreateResourceViewModel(IResourceService resourceService)
    {
        _resourceService = resourceService;
        CreateCommand = new AsyncRelayCommand(Create, CanCreate);
    }

    public string Name
    {
        get => _name;
        set
        {
            SetProperty(ref _name, value);
            CreateCommand.NotifyCanExecuteChanged();
        }
    }

    public decimal Quantity
    {
        get => _quantity;
        set => SetProperty(ref _quantity, value);
    }

    public AsyncRelayCommand CreateCommand { get; private set; }

    private async Task Create()
    {
        await _resourceService.Create(Name, Quantity);
    }
    
    private bool CanCreate()
    {
        return !string.IsNullOrEmpty(Name);
    }
}