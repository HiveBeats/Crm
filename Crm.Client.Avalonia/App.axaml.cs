using Applicat = Avalonia.Application;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;

using Crm.Client.Avalonia.ViewModels;
using Crm.Client.Avalonia.Views;
using Crm.Server.Infrastructure.Database;

namespace Crm.Client.Avalonia;
public partial class App : Applicat
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDatabaseService();
    }
    
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Line below is needed to remove Avalonia data validation.
            // Without this line you will get duplicate validations from both Avalonia and CT
            ExpressionObserver.DataValidators.RemoveAll(x => x is DataAnnotationsValidationPlugin);
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}