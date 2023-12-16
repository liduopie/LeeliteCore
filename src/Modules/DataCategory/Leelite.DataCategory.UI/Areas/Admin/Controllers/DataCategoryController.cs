using Leelite.AspNetCore.Models;
using Leelite.DataCategory.Dtos.CategoryDtos;
using Leelite.DataCategory.Dtos.CategoryTypeDtos;
using Leelite.DataCategory.Interfaces;
using Leelite.Web.Areas.Admin.Models;

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

        public IActionResult CategoryTypeCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CategoryTypeCreate([Bind("Name")] CategoryTypeCreateRequest request)
        {
            try
            {
                await _categoryTypeService.CreateAsync(request);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult CategoryTypeEdit(int id)
        {
            var model = _categoryTypeService.GetById(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CategoryTypeEdit(int id, [Bind("Id,Name")] CategoryTypeUpdateRequest request)
        {
            try
            {
                await _categoryTypeService.UpdateAsync(request);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult CategoryCreate(int categoryTypeId, long parentId)
        {
            ViewBag.CategoryTypeId = categoryTypeId;
            ViewBag.ParentId = parentId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CategoryCreate([Bind("CategoryTypeId,Code,Name,ParentId,Description,Sort")] CategoryCreateRequest request)
        {
            try
            {
                await _categoryService.CreateAsync(request);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult CategoryEdit(int id)
        {
            var model = _categoryService.GetById(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CategoryEdit(int id, [Bind("Id,CategoryTypeId,Code,Name,ParentId,Description,Sort")] CategoryUpdateRequest request)
        {
            try
            {
                await _categoryService.UpdateAsync(request);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CategoryDelete(int id)
        {
            try
            {
                await _categoryService.DeleteAsync(id);

                return Ok(new ResultModel()
                {
                    success = true
                });
            }
            catch (Exception e)
            {
                return Ok(new ResultModel()
                {
                    success = false,
                    message = e.Message
                });
            }
        }
    }
}
