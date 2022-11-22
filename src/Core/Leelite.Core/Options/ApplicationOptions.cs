namespace Leelite.Core.Options
{
    public abstract class ApplicationOptions
    {
        /// <summary>
        /// 应用名称
        /// </summary>
        public string ApplicationName { get; set; } = "Leelite";

        /// <summary>
        /// 应用功能描述
        /// </summary>
        public string Description { get; set; } = "";

        /// <summary>
        /// 关键字
        /// </summary>
        public string Keywords { get; set; } = "";
    }
}
