using Leelite.DataCategory.Dtos.CategoryTypeDtos;
using Leelite.DataCategory.Interfaces;
using Leelite.Web.Models;

using Microsoft.AspNetCore.Mvc;

namespace Leelite.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DataCategoryController : Controller
    {
        private readonly ICategoryTypeService _categoryTypeService;
        private readonly ICategoryService _categoryService;

        public DataCategoryController(ICategoryTypeService categoryTypeService, ICategoryService categoryService)
        {
            _categoryTypeService = categoryTypeService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(int categoryTypeId)
        {
            var defTypeId = categoryTypeId;

            // 获取所有数据分类类别
            var categoryTypeQuery = new CategoryTypeQueryParameter();

            var categoryTypeList = await _categoryTypeService.GetAsync(categoryTypeQuery);

            if (defTypeId == 0 && categoryTypeList.Count > 0)
            {
                defTypeId = categoryTypeList[0].Id;
            }

            // 获取数据分类
            var categoryTree = await _categoryService.GetCategoryTreeByTypeAsync(defTypeId);

            var model = new DataCategoryViewModel()
            {
                CategoryTypes = categoryTypeList,
                ActiveCategoryType = categoryTypeList.FirstOrDefault(c => c.Id == defTypeId),
                CategoryTree = categoryTree
            };

            return View(model);
        }
    }
}
