using Leelite.Core.Module;
using Leelite.DataCategory.Contexts;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.DataCategory
{
    public class DataCategoryModule : ModuleBase
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataCategoryContext>("Default");
        }
    }
}
