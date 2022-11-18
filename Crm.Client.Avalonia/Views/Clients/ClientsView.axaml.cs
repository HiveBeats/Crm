using Avalonia;
using Avalonia.Controls;
using Avalonia.LogicalTree;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Avalonia.VisualTree;
using Crm.Client.Avalonia.ViewModels;
using Crm.Client.ViewModel.Clients;
using ReactiveUI;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;

namespace Crm.Client.Avalonia.Views.Clients;

public partial class ClientsView : ReactiveUserControl<ClientsViewModel>
{
    public ClientsView()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.ShowCreateOrderDialog.RegisterHandler(DoShowDialogAsync)));
    }

    private async Task DoShowDialogAsync(InteractionContext<CreateClientOrderViewModel, Unit> interaction)
    {
        var dialog = new CreateClientOrderWindow();
        dialog.DataContext = interaction.Input;
        var parents = this.GetSelfAndVisualAncestors();
        var result = await dialog.ShowDialog<Unit>(parents.Last() as Window);
        interaction.SetOutput(result);
    }
}