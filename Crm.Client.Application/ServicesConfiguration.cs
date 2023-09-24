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
        service.AddTransient<ClientOrdersService>();
        service.AddTransient<ClientService>();
        service.AddTransient<DepartmentsService>();
        service.AddTransient<EmployeeClientsService>();
        service.AddTransient<EmployeeService>();
        service.AddTransient<OrdersService>();
        service.AddTransient<ResourceService>();
    }
}