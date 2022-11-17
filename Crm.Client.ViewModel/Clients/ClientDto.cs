using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Client.ViewModel.Clients;
public class ClientDto: ReactiveObject
{
    private string _name;
    private string _contact;

    public string Name { get { return _name; } set => this.RaiseAndSetIfChanged(ref _name, value); }
    public string Contact { get => _contact; set => this.RaiseAndSetIfChanged(ref _contact, value); }   
}
