using System.Collections.Generic;
using Leelite.Framework.Domain.Aggregate;

namespace Leelite.Modules.Application.Models.ApplicationAgg
{
    public class Application : AggregateRoot<string>
    {
        /// <summary>
        /// 应用名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        public virtual IList<ModuleItem> Modules { get; set; }

        public virtual IList<FeatureItem> FunctionItems { get; set; }

        public virtual IList<MenuItem> Menus { get; set; }

        public virtual IList<ShortcutItem> Shortcuts { get; set; }
    }
}
