using Microsoft.Extensions.Configuration;

namespace Leelite.Extensions.EntityFramework.Connection
{
    public class ConfigConnectionStringFactory : IConnectionStringFactory
    {
        private readonly IConfiguration _configuration;

        public ConfigConnectionStringFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString(string name)
        {
            return _configuration.GetConnectionString(name);
        }
    }
}
