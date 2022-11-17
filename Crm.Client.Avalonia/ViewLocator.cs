using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Crm.Client.Avalonia.ViewModels;
using System;

namespace Crm.Client.Avalonia;
public class ViewLocator : IDataTemplate
{
    public IControl Build(object data)
    {
        var name = data.GetType().FullName!.Replace("Crm.Client.ViewModel", "Crm.Client.Avalonia.Views").Replace("ViewModel", "View");
        var type = Type.GetType(name);

        if (type != null)
        {
            return (Control)Activator.CreateInstance(type)!;
        }

        return new TextBlock { Text = "Not Found: " + name };
    }

    public bool Match(object data)
    {

        return data is Crm.Client.ViewModel.Common.ViewModelBase;
    }
}