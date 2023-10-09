using System.Linq;
using Crm.Client.ViewModel.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Crm.Client.ViewModel;

public static class ServicesConfiguration
{
    public static void AddViewModels(this IServiceCollection service)
    {
        var assembly = typeof(ViewModelBase).Assembly;

        var viewModels = (from assemblyType in assembly.GetExportedTypes()
            where assemblyType.GetInterface(nameof(IPageViewModel)) != null
            select assemblyType).ToArray();

        foreach (var vm in viewModels) service.AddTransient(vm);

        service.AddTransient<InitializableViewModelFactory>();
    }
}