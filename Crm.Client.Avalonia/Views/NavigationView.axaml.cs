using Avalonia.ReactiveUI;
using Crm.Client.ViewModel;
using ReactiveUI;

namespace Crm.Client.Avalonia.Views;

public partial class NavigationView : ReactiveUserControl<NavigationViewModel>
{
    public NavigationView()
    {
        InitializeComponent();
        this.WhenActivated(disposables => { });
    }
}