﻿using System;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using Splat;

namespace Crm.Client.ViewModel.Common;

public class MainWindowViewModel : ViewModelBase
{
    private Crm.Client.ViewModel.Common.ViewModelBase _currentViewModel;
    
    public MainWindowViewModel(): base()
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
        set => SetProperty(ref _currentViewModel, value); 
    }
    
    public static IServiceProvider ServiceProvider { get; private set; }
}
