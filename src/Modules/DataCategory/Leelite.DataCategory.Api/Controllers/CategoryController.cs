using Leelite.DataCategory.Dtos.CategoryDtos;
using Leelite.DataCategory.Interfaces;
using Leelite.DataCategory.Models.CategoryAgg;
using Leelite.Framework.WebApi;

using Microsoft.AspNetCore.Mvc;

namespace Leelite.DataCategory.Api
{
    [Area("DataCategory")]
    public class CategoryController : RESTfulController<Category, long, CategoryDto, CategoryCreateRequest, CategoryUpdateRequest, CategoryQueryParameter>
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service) : base(service)
        {
            _service = service;
        }
    }
}