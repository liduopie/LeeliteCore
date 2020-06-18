using System;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Leelite.Commons.Dependency
{
    //public class AutofacContainer_UnitTest
    //{
    //    [Fact]
    //    public void ContainerContext_RegisterType_Test()
    //    {
    //        var serviceContainer = new AutofacServiceContainer();

    //        var builder = serviceContainer.Builder;

    //        builder.RegisterType<Operation>().As<IOperationTransient>();

    //        Assert.Equal(1, serviceContainer.Builder.Properties.Count);

    //        serviceContainer.Build();

    //        var operation = serviceContainer.Container.Resolve<IOperationTransient>();

    //        Assert.NotNull(operation);
    //    }

    //    [Fact]
    //    public void ContainerContext_Resolve_Test()
    //    {
    //        var serviceContainer = new AutofacServiceContainer();

    //        var builder = serviceContainer.Builder;

    //        builder.RegisterInstance<IOperationSingletonInstance>(new Operation(Guid.Empty));
    //        builder.RegisterType<Operation>().As<IOperationSingleton>().SingleInstance();
    //        builder.RegisterType<Operation>().As<IOperationScoped>().InstancePerLifetimeScope();
    //        builder.RegisterType<Operation>().As<IOperationTransient>().InstancePerDependency();

    //        builder.RegisterType<OperationService>().AsSelf().InstancePerDependency();

    //        serviceContainer.Build();

    //        var operationService1 = serviceContainer.ServiceProvider.GetService<OperationService>();

    //        using (var scope = serviceContainer.ServiceProvider.CreateScope())
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
