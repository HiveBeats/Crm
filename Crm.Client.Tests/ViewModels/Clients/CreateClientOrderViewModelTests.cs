using System;
using Crm.Client.Application.Clients;
using Crm.Client.ViewModel.Clients;
using FakeItEasy;
using Xunit;
using Task = System.Threading.Tasks.Task;

namespace Crm.Client.Tests.ViewModels.Clients;

public class CreateClientOrderViewModelTests
{
    [Fact]
    public void ShouldNotBeAbleToCreate_IfNameIsNull()
    {
        //arrange
        var client = new Domain.Models.Client("test", "test");
        var service = MockClientOrdersService(client, null, "");
        
        //act
        var vm = new CreateClientOrderViewModel(client, service);
        vm.Name = null;
        
        //assert
        Assert.False(vm.CreateCommand.CanExecute(null));
    }
    
    [Fact]
    public void ShouldBeAbleToCreate_IfNameIsNotNull()
    {
        //arrange
        var client = new Domain.Models.Client("test", "test");
        var service = MockClientOrdersService(client, null, "");
        
        //act
        var vm = new CreateClientOrderViewModel(client, service);
        vm.Name = "test";
        
        //assert
        Assert.True(vm.CreateCommand.CanExecute(null));
    }

    private IClientOrdersService MockClientOrdersService(Domain.Models.Client client, string name, string description)
    {
        var service = A.Fake<IClientOrdersService>();
        A.CallTo(() => service.Create(client, name, description)).Returns(Task.FromResult(Guid.NewGuid()));
        return service;
    }
}