namespace Leelite.Application.Options
{
    public class ApplicationOptions
    {
        /// <summary>
        /// 应用名称
        /// </summary>
        public string ApplicationName { get; set; } = "";

        /// <summary>
        /// 应用功能描述
        /// </summary>
        public string Description { get; set; } = "";

        /// <summary>
        /// 关键字
        /// </summary>
        public string Keywords { get; set; } = "";

        /// <summary>
        /// 启动路径
        /// </summary>
        public string StartUrl { get; set; } = "";
    }
}
