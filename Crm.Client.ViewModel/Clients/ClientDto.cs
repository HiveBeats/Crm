using CommunityToolkit.Mvvm.ComponentModel;

namespace Crm.Client.ViewModel.Clients;

public class ClientDto : ObservableObject
{
    private string _contact;
    private string _name;

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public string Contact
    {
        get => _contact;
        set => SetProperty(ref _contact, value);
    }
}