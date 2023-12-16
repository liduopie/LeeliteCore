using Leelite.DataDictionary.Dtos.DataItemDtos;
using Leelite.DataDictionary.Dtos.DataTypeDtos;
using Leelite.DataDictionary.Models.DataTypeAgg;
using Leelite.Framework.Data.Query.Paging;

namespace Leelite.Web.Areas.Admin.Models
{
    public class DataDictionaryViewModel
    {
        public IList<DataTypeDto> SystemTypes { get; set; }
        public IList<DataTypeDto> OrganizationTypes { get; set; }

        public OwnerType ActiveOwnerType { get; set; }

        /// <summary>
        /// 激活的数据字典
        /// </summary>
        public DataTypeDto ActiveType { get; set; }

        public DataItemQueryParameter QueryParameter { get; set; }
        public PageList<DataItemDto> PageList { get; set; }
    }
}
