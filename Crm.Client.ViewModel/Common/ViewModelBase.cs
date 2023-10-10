using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Crm.Client.ViewModel.Common;

public class ViewModelBase : ObservableObject, IInitializableViewModel
{
    protected ViewModelBase()
    {
    }

    public virtual Task InitAsync()
    {
        throw new System.NotImplementedException();
    }
}