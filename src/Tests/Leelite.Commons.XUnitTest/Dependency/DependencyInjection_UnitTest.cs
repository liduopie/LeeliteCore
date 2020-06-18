using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Leelite.Commons.Dependency;
using System.Linq;

namespace Leelite.Commons.Dependency
{
    //public class DependencyInjection_UnitTest
    //{
    //    [Fact]
    //    public void RegisterAssemblyTypes_Test()
    //    {
    //        var services = new ServiceCollection();

    //        var assembly = typeof(DependencyInjection_UnitTest).Assembly;

    //        var interfaceType = typeof(IOperation);

    //        var data = services.RegisterAssemblyTypes(assembly)
    //            .Where(type => interfaceType.IsAssignableFrom(type))
    //            .As(type => type.GetInterfaces())
    //            .AsSelf()
    //            .With(ServiceLifetime.Scoped);

    //        Assert.Equal(6, data.Services.Count);
    //    }

    //    [Fact]
    //    public void ContainerContext_RegisterType_Test()
    //    {
    //        var services = new ServiceCollection();

    //        services.AddTransient<IOperationTransient, Operation>();

    //        Assert.Single(services);

    //        var serviceProvider = services.BuildServiceProvider();

    //        var operation = serviceProvider.GetService<IOperationTransient>();

    //        Assert.NotNull(operation);
    //    }

    //    [Fact]
    //    public void ContainerContext_Resolve_Test()
    //    {
    //        var services = new ServiceCollection();

    //        services.AddSingleton<IOperationSingletonInstance>(new Operation(Guid.Empty));
    //        services.AddSingleton<IOperationSingleton, Operation>();
    //        services.AddScoped<IOperationScoped, Operation>();
    //        services.AddTransient<IOperationTransient, Operation>();

    //        services.AddTransient<OperationService>();

    //        var serviceProvider = services.BuildServiceProvider();

    //        var operationService1 = serviceProvider.GetService<OperationService>();

    //        using (var scope = serviceProvider.CreateScope())
    //        {
    //            var operationService2 = scope.ServiceProvider.GetService<OperationService>();

    //            Assert.Equal(operationService1.SingletonInstanceOperation.OperationId, operationService2.SingletonInstanceOperation.OperationId);
    //            Assert.Equal(operationService1.SingletonOperation.OperationId, operationService2.SingletonOperation.OperationId);

    //            Assert.NotEqual(operationService1.ScopedOperation.OperationId, operationService2.ScopedOperation.OperationId);

    //            var operationService3 = scope.ServiceProvider.GetService<OperationService>();

    //            Assert.Equal(operationService2.SingletonInstanceOperation.OperationId, operationService3.SingletonInstanceOperation.OperationId);
    //            Assert.Equal(operationService2.SingletonOperation.OperationId, operationService3.SingletonOperation.OperationId);

    //            Assert.Equal(operationService2.ScopedOperation.OperationId, operationService3.ScopedOperation.OperationId);
    //            Assert.NotEqual(operationService2.TransientOperation.OperationId, operationService3.TransientOperation.OperationId);
    //        }

    //    }
    //}
}
