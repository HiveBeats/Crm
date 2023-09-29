using HanumanInstitute.MvvmDialogs.Avalonia;

namespace Crm.Client.Avalonia;

public class WindowLocator: ViewLocatorBase
{
    protected override string GetViewName(object viewModel)
    {
        return viewModel.GetType().FullName!.Replace("Crm.Client.ViewModel", "Crm.Client.Avalonia.Views").Replace("ViewModel", "Window");
    }
}