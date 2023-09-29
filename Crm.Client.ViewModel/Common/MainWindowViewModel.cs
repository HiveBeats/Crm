﻿using System;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using Splat;

namespace Crm.Client.ViewModel.Common;

public class MainWindowViewModel : ViewModelBase
{
    private Crm.Client.ViewModel.Common.ViewModelBase _currentViewModel;
    
    public MainWindowViewModel(): base(new ViewModelActivator())
    {   
        
    }

    public void Initialize(IServiceProvider sp)
    {
        ServiceProvider = sp;
        CurrentViewModel = sp.GetRequiredService<NavigationViewModel>();
    }

    public ViewModelBase CurrentViewModel 
    { 
        get => _currentViewModel; 
        set => this.RaiseAndSetIfChanged(ref _currentViewModel, value); 
    }
    
    public static IServiceProvider ServiceProvider { get; private set; }
}
