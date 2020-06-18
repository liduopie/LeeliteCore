using System.Collections.Generic;
using Leelite.Framework.Domain.Model;

namespace Leelite.Modules.Application.Models.ApplicationAgg
{
    public class ShortcutItem : ValueObject<ShortcutItem>
    {
        /// <summary>
        /// 应用代码
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 快捷方式Id
        /// </summary>
        public int ShortcutId { get; set; }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new object[] { AppId, ShortcutId };
        }
    }
}
