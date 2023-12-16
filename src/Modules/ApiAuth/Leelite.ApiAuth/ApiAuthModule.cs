using Leelite.ApiAuth.CommandHandlers.WordLibraryHandlers;
using Leelite.ApiAuth.Contexts;
using Leelite.ApiAuth.Dtos.ApiKeyDtos;
using Leelite.ApiAuth.Models.ApiKeyAgg;
using Leelite.Core.Module;
using Leelite.Framework.Service.Commands;

using MediatR;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.ApiAuth
{
    public class ApiAuthModule : ModuleBase
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApiAuthContext>("Default");

            services.AddTransient<IRequestHandler<CreateCommand<ApiKeyCreateRequest, ApiKeyDto, ApiKey, long>, ApiKeyDto>, ApiKeyCreateCommandHandler>();
        }
    }
}
