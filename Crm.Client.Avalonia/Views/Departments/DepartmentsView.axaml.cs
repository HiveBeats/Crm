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

public partial class DepartmentsView : UserControl
{
    public DepartmentsView()
    {
        InitializeComponent();
    }
}