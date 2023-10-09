using Avalonia;
using Avalonia.Controls;
using Avalonia.LogicalTree;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Avalonia.VisualTree;
using Crm.Client.ViewModel.Clients;
using ReactiveUI;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;

namespace Crm.Client.Avalonia.Views.Clients;

public partial class ClientsView : UserControl
{
    public ClientsView()
    {
        InitializeComponent();
    }
}