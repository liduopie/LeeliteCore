using Leelite.DataCategory.Dtos.CategoryTypeDtos;
using Leelite.DataCategory.Interfaces;
using Leelite.DataCategory.Models.CategoryTypeAgg;
using Leelite.Framework.WebApi;

using Microsoft.AspNetCore.Mvc;

namespace Leelite.DataCategory.Api
{
    [Area("DataCategory")]
    public class CategoryTypeController : RESTfulController<CategoryType, int, CategoryTypeDto, CategoryTypeCreateRequest, CategoryTypeUpdateRequest, CategoryTypeQueryParameter>
    {
        private readonly ICategoryTypeService _service;

        public CategoryTypeController(ICategoryTypeService service) : base(service)
        {
            _service = service;
        }
    }
}