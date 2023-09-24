using Crm.Client.ViewModel.Clients;
using Crm.Client.ViewModel.Departments;
using Crm.Client.ViewModel.Employees;
using Microsoft.Extensions.DependencyInjection;

namespace Crm.Client.ViewModel;

public static class ServicesConfiguration
{
    public static void AddViewModelServices(this IServiceCollection service)
    {
        service.AddTransient<AssignClientManagerViewModel>();
        service.AddTransient<CreateClientOrderViewModel>();
        service.AddTransient<CreateClientViewModel>();
        service.AddTransient<ClientOrdersViewModel>();
        service.AddTransient<ClientsPageViewModel>();
        service.AddTransient<ClientsViewModel>();
        service.AddTransient<CreateDepartmentViewModel>();
        service.AddTransient<DepartmentsViewModel>();
        service.AddTransient<EmployeeClientsViewModel>();
        service.AddTransient<EmployeesViewModel>();
    }
}