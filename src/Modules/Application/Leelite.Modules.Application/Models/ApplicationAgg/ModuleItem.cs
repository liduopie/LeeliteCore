using System.Collections.Generic;
using Leelite.Framework.Domain.Model;

namespace Leelite.Modules.Application.Models.ApplicationAgg
{
    /// <summary>
    /// 模块关系
    /// </summary>
    public class ModuleItem : ValueObject<ModuleItem>
    {
        /// <summary>
        /// 应用代码
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 模块代码
        /// </summary>
        public string ModuleCode { get; set; }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new object[] { AppId, ModuleCode };
        }
    }
}
