using Crm.Client.Application.Clients;
using Crm.Client.Application.Departments;
using Crm.Client.Application.Employees;
using Crm.Client.Application.Orders;
using Crm.Client.Application.Resources;
using Microsoft.Extensions.DependencyInjection;

namespace Crm.Client.Application;

public static class ServicesConfiguration
{
    public static void AddApplicationService(this IServiceCollection service)
    {
        service.AddTransient<IClientOrdersService, ClientOrdersService>();
        service.AddTransient<IClientService, ClientService>();
        service.AddTransient<IDepartmentsService, DepartmentsService>();
        service.AddTransient<IEmployeeClientsService, EmployeeClientsService>();
        service.AddTransient<IEmployeeService, EmployeeService>();
        service.AddTransient<IOrdersService, OrdersService>();
        service.AddTransient<IResourceService, ResourceService>();
    }
}