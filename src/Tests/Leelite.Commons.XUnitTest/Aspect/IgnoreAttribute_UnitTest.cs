using Leelite.Commons.Dependency;
using Xunit;

namespace Leelite.Commons.Aspect
{
    //public class IgnoreAttribute_UnitTest
    //{
    //    [Fact]
    //    public void Aspect_UnitTest()
    //    {
    //        var proxy = GetService();
    //        Assert.Equal("lemon", proxy.Aspect());
    //    }

    //    [Fact]
    //    public void NonAspect_UnitTest()
    //    {
    //        var proxy = GetService();
    //        Assert.Equal("le", proxy.NonAspect());
    //    }

    //    [Fact]
    //    public void IgnoreAspect_UnitTest()
    //    {
    //        var proxy = GetService();
    //        Assert.Equal("le", proxy.IgnoreAspect());
    //    }

    //    private IFakeNonAspect GetService()
    //    {
    //        var serviceContainer = new AutofacServiceContainer();

    //        var builder = serviceContainer.Builder;

    //        builder.RegisterDynamicProxy(config =>
    //        {
    //            config.Interceptors.AddDelegate(async (ctx, next) =>
    //            {
    //                await ctx.Invoke(next);
    //                ctx.ReturnValue = "lemon";
    //            });
    //        });
    //        builder.RegisterType<FakeNonAspect>().As<IFakeNonAspect>();

    //        serviceContainer.Build();

    //        return serviceContainer.Container.Resolve<IFakeNonAspect>();
    //    }
    //}

    //public interface IFakeNonAspect
    //{
    //    string Aspect();

    //    [NonAspect]
    //    string NonAspect();

    //    [Ignore]
    //    string IgnoreAspect();
    //}

    //public class FakeNonAspect : IFakeNonAspect
    //{
    //    public string Aspect()
    //    {
    //        return "le";
    //    }

    //    public string IgnoreAspect()
    //    {
    //        return "le";
    //    }

    //    public string NonAspect()
    //    {
    //        return "le";
    //    }
    //}
}
