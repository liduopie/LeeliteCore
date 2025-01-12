using Leelite.DataCategory.Dtos.CategoryTypeDtos;
using Leelite.DataCategory.Interfaces;
using Leelite.DataCategory.Models.CategoryTypeAgg;
using Leelite.DataCategory.Repositories;
using Leelite.Framework.Domain.Command;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Framework.Service;

using Microsoft.Extensions.Logging;

namespace Leelite.DataCategory.Services
{
    public class CategoryTypeService : CrudService<CategoryType, int, CategoryTypeDto, CategoryTypeCreateRequest, CategoryTypeUpdateRequest, CategoryTypeQueryParameter>, ICategoryTypeService
    {
        public CategoryTypeService(
            ICategoryTypeRepository repository,
            ICommandBus commandBus,
            IUnitOfWork unitOfWork,
            ILogger<CategoryTypeService> logger
            ) : base(repository, commandBus, unitOfWork, logger)
        {
        }

        /// <inheritdoc/>
        public CategoryTypeDto GetByCode(string code)
        {
            var entity = Repository.Find(CategoryTypeCriteria.Code(code).SatisfiedBy()).FirstOrDefault();

            return MapTo<CategoryTypeDto>(entity);
        }

        /// <inheritdoc/>
        public CategoryTypeDto GetByName(string name)
        {
            var entity = Repository.Find(CategoryTypeCriteria.Name(name).SatisfiedBy()).FirstOrDefault();

            return MapTo<CategoryTypeDto>(entity);
        }
    }
}
