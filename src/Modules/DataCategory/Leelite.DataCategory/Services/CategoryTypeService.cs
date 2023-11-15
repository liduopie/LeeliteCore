using Leelite.DataCategory.Dtos.CategoryTypeDtos;
using Leelite.DataCategory.Interfaces;
using Leelite.DataCategory.Models.CategoryTypeAgg;
using Leelite.DataCategory.Repositories;
using Leelite.Framework.Domain.Command;
using Leelite.Framework.Service;

using Microsoft.Extensions.Logging;

namespace Leelite.DataCategory.Services
{
    public class CategoryTypeService : CrudService<CategoryType, int, CategoryTypeDto, CategoryTypeCreateRequest, CategoryTypeUpdateRequest, CategoryTypeQueryParameter>, ICategoryTypeService
    {
        public CategoryTypeService(
            ICategoryTypeRepository repository,
            ICommandBus commandBus,
            ILogger<CategoryTypeService> logger
            ) : base(repository, commandBus, logger)
        {
        }
    }
}
