namespace Leelite.Application.Clients
{
    /// <summary>
    /// 导航菜单
    /// </summary>
    public class NavItem
    {

        public NavItem(
            string target,
            string icon,
            string name,
            string description,
            string url,
            string code = "",
            string permission = "",
            string feature = "",
            int sort = 1)
        {
            Target = target;
            Icon = icon;
            Name = name;
            Description = description;
            Url = url;
            Code = code;
            PermissionDependency = permission;
            FeatureDependency = feature;
            Sort = sort;
        }

        /// <summary>
        /// 菜单编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 打开方式 "_blank", "_self", "_parent", "_top"
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Url链接
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 一个权限依赖。只有满足此权限依赖项的用户才能看到此菜单项。
        /// 可选的。
        /// </summary>
        public string PermissionDependency { get; set; }

        /// <summary>
        /// 一个特性的依赖。
        /// 可选的。
        /// </summary>
        public string FeatureDependency { get; set; }

        /// <summary>
        /// 如果只有经过身份验证的用户才能看到此菜单项，则可以将其设置为true。
        /// </summary>
        public bool RequiresAuthentication { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 此菜单项的子项。
        /// </summary>
        public virtual IList<NavItem> Items { get; } = new List<NavItem>();
    }
}
