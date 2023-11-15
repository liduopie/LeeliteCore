namespace Leelite.Application.Clients
{
    public class Client
    {
        public Client() { }

        public Client(string code, string logo, string name, string url, string description, int order = 1000)
        {
            Code = code;
            Logo = logo;
            Name = name;
            DefaultUrl = url;
            Description = description;
            Sort = order;
        }

        /// <summary>
        /// 应用编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 应用图标
        /// </summary>
        public string Logo { get; set; }

        /// <summary>
        /// 应用名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 默认入口
        /// </summary>
        public string DefaultUrl { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 子应用入口
        /// </summary>
        public IList<NavItem> SubApps { get; set; } = new List<NavItem>();

        /// <summary>
        /// 顶部导航菜单
        /// </summary>
        public IList<NavItem> NavMenus { get; set; } = new List<NavItem>();

        /// <summary>
        /// 侧边导航菜单
        /// </summary>
        public IList<NavItem> SideMenus { get; set; } = new List<NavItem>();

        /// <summary>
        /// 快捷入口
        /// </summary>
        public IList<NavItem> Shortcuts { get; set; } = new List<NavItem>();

        public void AddNavMenus(params NavItem[] items)
        {
            foreach (var item in items)
            {
                NavMenus.Add(item);
            }

            NavMenus = NavMenus.OrderBy(m => m.Sort).ToList();
        }
    }
}
