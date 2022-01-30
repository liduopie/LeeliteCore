using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Commons.Host
{
    /// <summary>
    /// Default implementation of <see cref="IServiceProviderFactory{TContainerBuilder}"/>.
    /// </summary>
    public class CoreHostServiceProviderFactory : IServiceProviderFactory<IServiceCollection>
    {
        private readonly ServiceProviderOptions _options;

        /// <summary>
        /// Initializes a new instance of the <see cref="CoreHostServiceProviderFactory"/> class
        /// with default options.
        /// </summary>
        /// <seealso cref="ServiceProviderOptions"/>
        public CoreHostServiceProviderFactory()
        {
            _options = new ServiceProviderOptions();
        }

        /// <inheritdoc />
        public IServiceCollection CreateBuilder(IServiceCollection services)
        {
            return services;
        }

        /// <inheritdoc />
        public IServiceProvider CreateServiceProvider(IServiceCollection containerBuilder)
        {
            HostManager.Context.HostServices = containerBuilder.BuildServiceProvider(_options);

            return HostManager.Context.HostServices;
        }
    }
}
