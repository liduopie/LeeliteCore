using Leelite.Core.Module;
using Leelite.DataDictionary.Contexts;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.DataDictionary
{
    public class DataDictionaryModule : ModuleBase
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataDictionaryContext>("Default");
        }
    }
}
