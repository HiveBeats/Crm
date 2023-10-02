using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Crm.Client.ViewModel.Clients;
public class ClientDto: ObservableObject
{
    private string _name;
    private string _contact;

    public string Name { get { return _name; } set => SetProperty(ref _name, value); }
    public string Contact { get => _contact; set => SetProperty(ref _contact, value); }   
}
