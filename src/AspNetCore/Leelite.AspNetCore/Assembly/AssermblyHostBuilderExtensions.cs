using Leelite.AspNetCore.Assembly.Loader;
using Leelite.Commons.Assembly.Loader;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Leelite.AspNetCore.Assembly
{
    public static class AssermblyHostBuilderExtensions
    {
        public static IHostBuilder ConfigureAssermblyLoader(this IHostBuilder builder)
        {
            builder.ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<IAssemblyLoader>(new CollectibleAssemblyLoader());
            });

            return builder;
        }
    }
}