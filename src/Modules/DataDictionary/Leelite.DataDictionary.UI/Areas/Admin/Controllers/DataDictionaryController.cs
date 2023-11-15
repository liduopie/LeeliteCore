using Leelite.DataDictionary.Dtos.DataItemDtos;
using Leelite.DataDictionary.Dtos.DataTypeDtos;
using Leelite.DataDictionary.Interfaces;
using Leelite.DataDictionary.Models.DataTypeAgg;
using Leelite.Web.Models;

using Microsoft.AspNetCore.Mvc;

namespace Leelite.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DataDictionaryController : Controller
    {
        private readonly IDataTypeService _dataTypeService;
        private readonly IDataItemService _dataItemService;

        public DataDictionaryController(IDataTypeService dataTypeService, IDataItemService dataItemService)
        {
            _dataTypeService = dataTypeService;
            _dataItemService = dataItemService;
        }

        public async Task<IActionResult> Index(string keyword, string dataType, OwnerType ownerType = OwnerType.System, int page = 1)
        {
            var defType = dataType;

            // 获取所有数据字典
            var dataTypeQuery = new DataTypeQueryParameter();

            var dataTypeList = await _dataTypeService.GetAsync(dataTypeQuery);

            if (string.IsNullOrEmpty(defType) && dataTypeList.Count > 0)
            {
                defType = dataTypeList[0].Id;
            }

            var activeType = dataTypeList.FirstOrDefault(c => c.Id == defType);

            // 数据字典的数据项
            var dataItemQuery = new DataItemQueryParameter();

            dataItemQuery.Keyword = keyword;
            dataItemQuery.DataTypeId = defType;
            dataItemQuery.Pager.Page = page;

            var dataItemList = await _dataItemService.GetPageListAsync(dataItemQuery);

            var model = new DataDictionaryViewModel()
            {
                SystemTypes = dataTypeList.Where(c => c.OwnerType == OwnerType.System).ToList(),
                OrganizationTypes = dataTypeList.Where(c => c.OwnerType == OwnerType.Organization).ToList(),
                ActiveOwnerType = ownerType,
                ActiveType = activeType,
                QueryParameter = dataItemQuery,
                PageList = dataItemList
            };

            return View(model);
        }
    }
}
