using System.Collections.Generic;

using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Models.Enabled;

namespace Leelite.MessageCenter.Models.PushPlatformAgg
{
    /// <summary>
    /// 平台信息
    /// </summary>
    public class PushPlatform : AggregateRoot<int>,
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
        /// 平台编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 提供程序
        /// </summary>
        public string ProviderName { get; set; }

        /// <summary>
        /// 配置参数
        /// </summary>
        public IDictionary<string, string> Config { get; set; }

        /// <summary>
        /// 优先级,数量越小越优先
        /// </summary>
        public int Priority { get; set; }

        /// <inheritdoc/>
        public bool IsEnabled { get; set; }
    }
}
