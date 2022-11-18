using Avalonia.ReactiveUI;
using Crm.Client.ViewModel.Clients;
using ReactiveUI;
using System;

namespace Crm.Client.Avalonia.Views.Clients;

public partial class CreateClientOrderWindow : ReactiveWindow<CreateClientOrderViewModel>
{
    public CreateClientOrderWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.CreateCommand.Subscribe(_ => Close())));
        this.WhenActivated(d => d(ViewModel!.CancelCommand.Subscribe(_ => Close())));
    }
}