using Applicat = Avalonia.Application;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Crm.Client.Application;
using Microsoft.Extensions.DependencyInjection;

using Crm.Client.Avalonia.ViewModels;
using Crm.Client.Avalonia.Views;
using Crm.Client.ViewModel;
using Crm.Client.ViewModel.Common;
using Crm.Server.Infrastructure.Database;
using Microsoft.Extensions.Configuration;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.Avalonia;

namespace Crm.Client.Avalonia;
public partial class App : Applicat
{
    public IConfiguration Configuration { get; set; } = 
        new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", true, false)
        .AddJsonFile("appsettings.dev.json", true, false)
        .Build();
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton(Configuration);
        services.AddDatabase(Configuration.GetConnectionString("NpgConnection"));
        services.AddViewModels();
        services.AddApplicationServices();
        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<IDialogService>(new DialogService(
            new DialogManager(
                viewLocator:new WindowLocator()), 
                viewModelFactory: x => MainWindowViewModel.ServiceProvider.GetRequiredService(x)));
    }
    
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var servicesCollection = new ServiceCollection();
        ConfigureServices(servicesCollection);
        var serviceProvider = servicesCollection.BuildServiceProvider();
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Line below is needed to remove Avalonia data validation.
            // Without this line you will get duplicate validations from both Avalonia and CT
            var mainVm = serviceProvider.GetRequiredService<MainWindowViewModel>();
            mainVm.Initialize(serviceProvider);
            
            ExpressionObserver.DataValidators.RemoveAll(x => x is DataAnnotationsValidationPlugin);
            desktop.MainWindow = new MainWindow
            {
                DataContext = mainVm,
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}