using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Avalonia.VisualTree;
using Crm.Client.Avalonia.Views.Clients;
using Crm.Client.ViewModel.Clients;
using Crm.Client.ViewModel.Departments;
using Crm.Domain.Models;
using ReactiveUI;
using System;
using System.Linq;
using System.Reactive;

namespace Crm.Client.Avalonia.Views.Departments;

public partial class DepartmentsView : ReactiveUserControl<DepartmentsViewModel>
{
    public DepartmentsView()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.ShowCreateDialog.RegisterHandler(DoShowDialogAsync)));
    }

    private async System.Threading.Tasks.Task DoShowDialogAsync(InteractionContext<CreateDepartmentViewModel, Department> interaction)
    {
        var dialog = new CreateDepartmentWindow();
        dialog.DataContext = interaction.Input;
        var parents = this.GetSelfAndVisualAncestors();
        var result = await dialog.ShowDialog<Department>(parents.Last() as Window);
        interaction.SetOutput(result);
    }
}