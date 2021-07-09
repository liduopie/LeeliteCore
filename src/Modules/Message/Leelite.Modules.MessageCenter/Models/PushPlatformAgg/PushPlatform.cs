
using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Models.Enabled;

namespace Leelite.Modules.MessageCenter.Models.PlatformAgg
{
    /// <summary>
    /// 平台信息
    /// </summary>
    public class PushPlatform : AggregateRoot<long>,
        IEnabled
    {
        /// <summary>
        /// 平台名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 平台描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 提供程序
        /// </summary>
        public string ProviderName { get; set; }

        /// <summary>
        /// 配置参数
        /// </summary>
        public string Config { get; set; }

        /// <summary>
        /// 优先级,数量越小越优先
        /// </summary>
        public int Priority { get; set; }

        /// <inheritdoc/>
        public bool IsEnabled { get; set; }
    }
}
