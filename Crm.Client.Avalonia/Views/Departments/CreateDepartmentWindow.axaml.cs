using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Crm.Client.ViewModel.Departments;
using ReactiveUI;
using System;

namespace Crm.Client.Avalonia.Views.Departments;

public partial class CreateDepartmentWindow : ReactiveWindow<CreateDepartmentViewModel>
{
    public CreateDepartmentWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.CreateCommand.Subscribe(_ => Close())));
        this.WhenActivated(d => d(ViewModel!.CancelCommand.Subscribe(_ => Close())));
    }
}