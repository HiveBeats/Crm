using Crm.Client.Application.Resources;
using Crm.Client.ViewModel.Common;
using ReactiveUI;
using System;

namespace Crm.Client.ViewModel.Resources;
public class CreateResourceViewModel : ViewModelBase
{
    private string _name;
    private decimal _quantity = 0;
    private IReactiveCommand _createCommand;
    private readonly IObservable<bool> _nameValidation; //todo: validations dictionary in base model
    private readonly IResourceService _resourceService;
    public CreateResourceViewModel(IResourceService resourceService) : base(new ViewModelActivator())
    {
        _resourceService = resourceService;

        _nameValidation = this.WhenAnyValue(x => x.Name, name => !string.IsNullOrWhiteSpace(name));
    }

    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    public decimal Quantity
    {
        get => _quantity;
        set => this.RaiseAndSetIfChanged(ref _quantity, value);
    }

    public IReactiveCommand CreateCommand => _createCommand ??= ReactiveCommand.CreateFromTask(async () =>
    {
        await _resourceService.Create(Name, Quantity);
    }, canExecute: _nameValidation);
}
