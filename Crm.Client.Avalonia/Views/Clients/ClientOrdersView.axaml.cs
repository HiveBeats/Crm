using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Crm.Client.ViewModel.Clients;
using ReactiveUI;

namespace Crm.Client.Avalonia.Views.Clients;

public partial class ClientOrdersView : ReactiveUserControl<ClientOrdersViewModel>
{
    public ClientOrdersView()
    {
        InitializeComponent();
        this.WhenActivated(disposables => { });
    }
}