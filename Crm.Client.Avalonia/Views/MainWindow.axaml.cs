using Avalonia.Controls;
using Avalonia.ReactiveUI;
using Crm.Client.Avalonia.ViewModels;
using Crm.Client.ViewModel.Common;

namespace Crm.Client.Avalonia.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
    }
}