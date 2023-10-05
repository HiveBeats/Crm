using System;
using Crm.Client.Application.Resources;
using Crm.Client.ViewModel.Common;
using ReactiveUI;

namespace Crm.Client.ViewModel.Resources;

public class CreateResourceViewModel : ViewModelBase
{
    private readonly IObservable<bool> _nameValidation; //todo: validations dictionary in base model
    private readonly IResourceService _resourceService;
    private IReactiveCommand _createCommand;
    private string _name;
    private decimal _quantity;

    public CreateResourceViewModel(IResourceService resourceService)
    {
        _resourceService = resourceService;

        _nameValidation = this.WhenAnyValue(x => x.Name, name => !string.IsNullOrWhiteSpace(name));
    }

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public decimal Quantity
    {
        get => _quantity;
        set => SetProperty(ref _quantity, value);
    }

    public IReactiveCommand CreateCommand => _createCommand ??=
        ReactiveCommand.CreateFromTask(async () => { await _resourceService.Create(Name, Quantity); }, _nameValidation);
}