using Leelite.Framework.WebApi;
using Leelite.DataCategory.Dtos.CategoryDtos;
using Leelite.DataCategory.Interfaces;
using Leelite.DataCategory.Models.CategoryAgg;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.DataCategory.Api
{
    [ApiController]
    [Area("DataCategory")]
    [Route("api/[area]/[controller]")]
    public class CategoryController : RESTfulController<Category, long, CategoryDto, CategoryCreateRequest, CategoryUpdateRequest, CategoryQueryParameter>
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service) : base(service)
        {
            _service = service;
        }
    }
}