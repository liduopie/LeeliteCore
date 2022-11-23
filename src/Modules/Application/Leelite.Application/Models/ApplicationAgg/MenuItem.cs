using Leelite.Framework.Domain.Model;

namespace Leelite.Application.Models.ApplicationAgg
{
    public class MenuItem : ValueObject<MenuItem>
    {
        /// <summary>
        /// 应用代码
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 菜单Id
        /// </summary>
        public int MenuId { get; set; }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new object[] { AppId, MenuId };
        }
    }
}
