using Leelite.Core.Module;
using Leelite.DataCategory.CommandHandlers;
using Leelite.DataCategory.Contexts;
using Leelite.DataCategory.Dtos.CategoryDtos;
using Leelite.DataCategory.Models.CategoryAgg;
using Leelite.Framework.Service.Commands;

using MediatR;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.DataCategory
{
    public class DataCategoryModule : ModuleBase
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataCategoryContext>("Default");

            services.AddTransient<IRequestHandler<CreateCommand<CategoryCreateRequest, CategoryDto, Category, long>, CategoryDto>, CategoryCreateCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateCommand<CategoryUpdateRequest, CategoryDto, Category, long>, CategoryDto>, CategoryUpdateCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteCommand<Category, long>, bool>, CategoryDeleteCommandHandler>();
        }
    }
}
