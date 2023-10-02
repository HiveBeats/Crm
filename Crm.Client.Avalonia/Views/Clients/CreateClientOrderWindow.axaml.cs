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
    }
}