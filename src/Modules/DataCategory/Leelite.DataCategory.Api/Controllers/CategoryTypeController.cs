using Leelite.Framework.WebApi;
using Leelite.DataCategory.Dtos.CategoryTypeDtos;
using Leelite.DataCategory.Interfaces;
using Leelite.DataCategory.Models.CategoryTypeAgg;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.DataCategory.Api
{
    [ApiController]
    [Area("DataCategory")]
    [Route("api/[area]/[controller]")]
    public class CategoryTypeController : RESTfulController<CategoryType, int, CategoryTypeDto, CategoryTypeCreateRequest, CategoryTypeUpdateRequest, CategoryTypeQueryParameter>
    {
        private readonly ICategoryTypeService _service;

        public CategoryTypeController(ICategoryTypeService service) : base(service)
        {
            _service = service;
        }
    }
}