using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Crm.Client.ViewModel.Clients;

namespace Crm.Client.Avalonia.Views.Clients;

public partial class ClientsView : ReactiveUserControl<ClientsViewModel>
{
    public ClientsView()
    {
        InitializeComponent();

    }
}