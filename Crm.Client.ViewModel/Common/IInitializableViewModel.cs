using System.Threading.Tasks;

namespace Crm.Client.ViewModel.Common;

public interface IInitializableViewModel
{ 
    Task InitAsync();
}