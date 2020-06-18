using System.Collections.Generic;
using System.Text.Json;
using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Models.Tree;

namespace Leelite.Modules.Application.Models.MenuAgg
{
    public class Menu : AggregateRoot<int>, ITree<int>
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 打开方式 "_blank", "_self", "_parent", "_top"
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Url链接
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 一个权限依赖。只有满足此权限依赖项的用户才能看到此菜单项。可选的。
        /// </summary>
        public string PermissionDependency { get; set; }

        /// <summary>
        /// 一个特性的依赖。可选的。
        /// </summary>
        public string FeatureDependency { get; set; }

        /// <summary>
        /// 如果只有经过身份验证的用户才能看到此菜单项，则可以将其设置为true。
        /// </summary>
        public bool RequiresAuthentication { get; set; }

        /// <summary>
        /// 如果该菜单项没有子元素 <see cref="Items"/>.
        /// </summary>
        public bool IsLeaf => Items == null | Items.Count == 0;

        /// <summary>
        /// 可用于启用/禁用菜单项。
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// 可以用来显示/隐藏菜单项。
        /// </summary>
        public bool IsVisible { get; set; }

        /// <summary>
        /// 可用于存储与此菜单项相关的自定义对象。可选的。
        /// </summary>
        public JsonDocument CustomData { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <inheritdoc/>
        public int ParentId { get; set; }

        /// <inheritdoc/>
        public string Path { get; set; }

        /// <inheritdoc/>
        public int Level { get; set; }

        /// <inheritdoc/>
        public int? SortId { get; set; }

        /// <summary>
        /// 此菜单项的子项。
        /// </summary>
        public virtual IList<Menu> Items { get; }
    }
}
