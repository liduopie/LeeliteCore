// using Autofac;
using Leelite.Commons.Convention;
using Leelite.Commons.Dependency;
using Xunit;

namespace Leelite.Commons.Lifetime
{
    //public class Lifetime_UnitTest
    //{
    //    [Fact]
    //    public void Lifetime_Test()
    //    {
    //        ConventionManager.AddRegistrar(new LifetimeConventionRegistrar());

    //        ConventionManager.RegisterAssembly(typeof(Operation).Assembly);

    //        ContainerManager.Build();

    //        var operationService1 = ContainerManager.Container.Resolve<OperationService>();

    //        using (var scope = ContainerManager.Container.BeginLifetimeScope("request"))
    //        {
    //            var operationService2 = scope.Resolve<OperationService>();

    //            Assert.Equal(operationService1.SingletonOperation.OperationId, operationService2.SingletonOperation.OperationId);
    //            Assert.NotEqual(operationService1.ScopedOperation.OperationId, operationService2.ScopedOperation.OperationId);

    //            var operationService3 = scope.Resolve<OperationService>();

    //            Assert.Equal(operationService2.SingletonOperation.OperationId, operationService3.SingletonOperation.OperationId);
    //            Assert.Equal(operationService2.ScopedOperation.OperationId, operationService3.ScopedOperation.OperationId);
    //            Assert.NotEqual(operationService2.TransientOperation.OperationId, operationService3.TransientOperation.OperationId);
    //        }
    //    }
    //}
}
